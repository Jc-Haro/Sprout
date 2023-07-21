using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float heal;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("InvPlayer"))
        {
            pHealth = collision.gameObject.GetComponent<PlayerHealth>();
            pHealth.health += pHealth.health + heal <= pHealth.maxHealth ? heal : pHealth.maxHealth-pHealth.health<heal ? pHealth.maxHealth - pHealth.health : 0;
            pHealth.HealSound();
            Destroy(gameObject);
        }
    }

   

}
