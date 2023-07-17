using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] float maxHP;
    private float actualHP;
    [SerializeField] private EnemyWorldHealthBar enemyHB;
    // Start is called before the first frame update
    private void Start()
    {
        actualHP = maxHP;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            actualHP--;
            enemyHB.UpdateHealth(actualHP, maxHP);
            if (actualHP < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
