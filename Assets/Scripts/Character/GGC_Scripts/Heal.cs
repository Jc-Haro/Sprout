using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pHealth = collision.gameObject.GetComponent<PlayerHealth>();
            pHealth.health += pHealth.health <= pHealth.maxHealth ? heal : 0;
            Destroy(gameObject);
        }
    }

}
