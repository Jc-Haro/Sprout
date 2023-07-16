using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSinMove : MonoBehaviour
{
    public AudioSource Phase2StartSound;
    [SerializeField] private float speed;
    private float sinCenterYPos;
    private float amplitude = 1.0f;
    private float minAmplitude = 0.5f;
    private float maxAmplitude = 1.5f;
    private float frequenzy = 1.0f;
    private float minFrequenzy = 0.5f;
    private float maxFrequenzy = 1.5f;
    public bool startMove = false;
    [SerializeField] private FungusDrop bossPhase2Attack;
    public int bossHP;
    [SerializeField] private GameObject nextLevelPortal;
    [SerializeField] private GameObject preciseShoot;
    [SerializeField] private HealthBar bossHb;
    [SerializeField] private GameObject bossUI;

    // Start is called before the first frame update
    void Start()
    {
        Phase2StartSound.Play();
        sinCenterYPos = 6;
        bossPhase2Attack.enabled = true;
    }

    private void FixedUpdate()
    {

        if (transform.position.y < 6 && !startMove)
        {
            Vector2 pos = transform.position;
            pos.y += 3.0f*Time.fixedDeltaTime ;
            transform.position = pos;
        }
        else
        {
            
            startMove = true;
            Vector2 pos = transform.position;

            float sin = Mathf.Sin(pos.x * frequenzy) * amplitude;
            pos.y = sinCenterYPos + sin;
            pos.x += speed * Time.fixedDeltaTime;
            transform.position = pos;

                if (transform.position.x > 17.5 || transform.position.x < -10)
                {
                    StartCoroutine(rotateSprite());
                    speed *= -1;
                }
        }

        


    }

    IEnumerator rotateSprite()
    {
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(new Vector3(0, 180, 0));
        frequenzy = Random.Range(minFrequenzy, maxFrequenzy);
        amplitude = Random.Range(minAmplitude, maxAmplitude);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            bossHP -= 1;
            bossHb.health = bossHP;
            if (bossHP <= 0)
            {
                bossUI.SetActive(false);
                Destroy(preciseShoot);
                nextLevelPortal.SetActive(true);
                Destroy(gameObject);
            }
        }

    }
}


