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
<<<<<<< HEAD
            pHealth.health += pHealth.health <= pHealth.maxHealth ? heal : 0;
=======
            pHealth.health += pHealth.health + heal <= pHealth.maxHealth ? heal : 0;
           
>>>>>>> 5c1f9cfd12306acbe2fbae56078c458c1d844a6d
            Destroy(gameObject);
        }
    }

}
