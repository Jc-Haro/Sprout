using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 22f;
    private bool isFacingRight = true;

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

    private void Start()
    {
        Mana = mana;
    }

    void Update()
    {
        manaBar.fillAmount = Mathf.Clamp(Mana / maxMana, 0, 1);
        horizontal = Input.GetAxisRaw("Horizontal");
        pState.moving = horizontal != 0;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            pState.jumping = true;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            pState.jumping = false;
        }
        if (mana < maxMana && !Input.GetKey(KeyCode.LeftShift))
        {
            Mana += manaPerSecond * Time.deltaTime;
        }
       


        Flip();
        Heal();
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
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            
            transform.localScale = localScale;
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

            //healing
            healTimer += Time.deltaTime;
            if (healTimer >= timeToHeal)
            {

                pHealth.health = pHealth.health + 5;
                healTimer = 0;
            }
            //drain mana
            Mana -= Time.deltaTime * manaDrainSpeed;
        }
        else
        {
            pState.healing = false;
            healTimer = 0;
        }
    }
}