using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
<<<<<<< HEAD
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
    }
=======
            if (collision.gameObject.CompareTag("Player"))
            {
                pHealth = collision.gameObject.GetComponent<PlayerHealth>();
                pHealth.health -= damage;
        
            }
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                pHealth = collision.gameObject.GetComponent<PlayerHealth>();
                pHealth.health -= damage;
               
            }
        }
    
>>>>>>> 5c1f9cfd12306acbe2fbae56078c458c1d844a6d
}
