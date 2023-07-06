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
                if (pHealth.healthBar.fillAmount > 0.60)
                {
                    pHealth.healthBar.color = Color.green;
                }
                else if (pHealth.healthBar.fillAmount > 0.3)
                {
                    pHealth.healthBar.color = new Color(1, 0.4f, 0.07f, 1); //105 255
                }
                else
                {
                    pHealth.healthBar.color = Color.red;
                }
            }
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                pHealth = collision.gameObject.GetComponent<PlayerHealth>();
                pHealth.health -= damage;
                if (pHealth.healthBar.fillAmount >= 0.60)
                {
                    pHealth.healthBar.color = Color.green;
                }
                else if (pHealth.healthBar.fillAmount >= 0.3)
                {
                    pHealth.healthBar.color = new Color(1, 0.4f, 0.07f, 1); 
                }
                else
                {
                    pHealth.healthBar.color = Color.red;
                }
            }
        }
    
}
