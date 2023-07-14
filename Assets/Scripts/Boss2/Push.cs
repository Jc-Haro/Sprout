using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public float pushForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("InvPlayer")) 
        {
            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 pushDirection = collision.transform.position - transform.position;
            playerRB.velocity = Vector2.zero;
            playerRB.angularVelocity = 0;
            playerRB.AddForce(pushDirection.normalized * pushForce, ForceMode2D.Impulse);
        }
    }
}
