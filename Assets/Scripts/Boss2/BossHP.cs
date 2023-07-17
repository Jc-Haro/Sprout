using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField] private HealthBar bossHp;
    [SerializeField] private int bossHitPoints;
    [SerializeField] private Boss2_trigger bossManager;
    [SerializeField] private Boss2_TP tp;

    private void Start()
    {
        bossHp.maxHealth = bossHitPoints;
        bossHp.health = bossHp.maxHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            bossHp.health--;
            Destroy(collision.gameObject);;
            if (bossHp.health <= 0)
            {
                bossManager.ActivateOnEnd();
                bossManager.DeactivateOnEnd();
                tp.StopAllCoroutines();
                tp.TurnOn_Platforms();
                Destroy(gameObject);
            }
        }
    }
}
