using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float damage;
    private PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlayerMovement>().Invincible();
            pHealth = collision.gameObject.GetComponent<PlayerHealth>();
            pHealth.health -= damage;
            pHealth.DamageSound();
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                
                collision.gameObject.GetComponent<PlayerMovement>().Invincible();
                pHealth = collision.gameObject.GetComponent<PlayerHealth>();
                pHealth.health -= damage;
                pHealth.DamageSound();
               
            }
        }
        
 
}
