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
            pHealth.health += pHealth.health + heal <= pHealth.maxHealth ? heal : 0;
            if (pHealth.healthBar.fillAmount >= 0.60)
            {
                pHealth.healthBar.color = Color.green;
            }
            else if (pHealth.healthBar.fillAmount >= 0.4)
            {
                pHealth.healthBar.color = new Color(1, 0.4f, 0.07f, 1); //105 255
            }
            else
            {
                pHealth.healthBar.color = Color.red;
            }
            Destroy(gameObject);
        }
    }

}
