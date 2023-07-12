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
    
}
