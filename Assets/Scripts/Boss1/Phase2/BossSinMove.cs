using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSinMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private float sinCenterYPos;
    private float amplitude = 1.0f;
    private float frequenzy = 1.0f;
    public bool startMove = false;
    [SerializeField] private FungusDrop bossPhase2Attack;

    // Start is called before the first frame update
    void Start()
    {
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

    }
}


