using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public AudioSource HealingSound;
    public AudioSource HealingOnBossArena;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 22f;
    private bool isFacingRight = true;
    public int invincibleTime;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private PlayerStateList pState;//new
    [SerializeField] private PlayerHealth pHealth;//new
    public float healTimer = 0;//new
    [SerializeField] float timeToHeal;//new

    [SerializeField] float mana;
    private float maxMana =  2;
    private float manaPerSecond = 0.05f;
    [SerializeField] float manaDrainSpeed;
    public Image manaBar;

    public GameObject sprite;
    public SpriteRenderer playerSprite;

    private bool isGrounded = false;

    [SerializeField] private GameObject healingSprite;

    [SerializeField] Sprite sproutJump;
    [SerializeField] Sprite sproutStanding;
    [SerializeField] Sprite sproutWalking;
    
    private void Start()
    {
        Mana = mana;
    }
    void Update()
    {
        manaBar.fillAmount = Mathf.Clamp(Mana / maxMana, 0, 1);
        horizontal = Input.GetAxisRaw("Horizontal");
        pState.moving = horizontal != 0;
        isGrounded = IsGrounded();
        pState.jumping = !isGrounded;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            pState.jumping = true;

        }
        SpriteState();
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (mana < maxMana && !Input.GetKey(KeyCode.LeftShift))
        {
            Mana += manaPerSecond * Time.deltaTime;
        }
        Flip();
        Heal();
    }

    private void SpriteState()
    {
        if (pState.jumping)
        {
            playerSprite.sprite = sproutJump;
        }
        else if (pState.moving)
        {
            playerSprite.sprite = sproutWalking;
        }
        else
        {
            playerSprite.sprite = sproutStanding;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = sprite.transform.localScale;
            localScale.x *= -1f;
            
            sprite.transform.localScale = localScale;
        }
    }

    float Mana 
    {
        get { return mana; }
        set
        {
            //if mana stats change
            if (mana != value)
            {
                mana = Mathf.Clamp(value, 0, 2);
            }
        }
    }
    void Heal()
    {
        if (Input.GetKey(KeyCode.LeftShift) && pHealth.health < pHealth.maxHealth && Mana > 0 && !pState.jumping && !pState.moving)
        {
            
            pState.healing = true;
            healingSprite.SetActive(true);

            //healing
            healTimer += Time.deltaTime;
            if(healTimer >= timeToHeal)
            {
                HealingSound.Play();
                HealingOnBossArena.Play();
                pHealth.health = pHealth.health + 5;
                Debug.Log("Shoulve healed");
                healTimer = 0;
            }
            //drain mana
            Mana -= Time.deltaTime * manaDrainSpeed;
        }
        else
        {
            pState.healing = false;
            healingSprite.SetActive(false);
            healTimer = 0;
        }
    }

    public void Invincible()
    {
        StartCoroutine(InvincibilityTime());   
    }

    IEnumerator InvincibilityTime()
    {
        Color tansparency = playerSprite.color;
        tansparency.a = 0.5f;
        playerSprite.color = tansparency;
        gameObject.tag = "InvPlayer";
        yield return new WaitForSeconds(invincibleTime);
        tansparency.a = 1.0f;
        playerSprite.color = tansparency;
        gameObject.tag = "Player";
    }
}