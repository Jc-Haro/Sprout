using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveWall : MonoBehaviour
{
    [SerializeField] private GameObject spawners;
    [SerializeField] private BoxCollider2D phase2Damage;
    [SerializeField] private int wallHp = 10;
    public BossSinMove phase2;
    [SerializeField] PreciseShoot preciseShoot;
    [SerializeField] private HealthBar bossHB;
  

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet")) {
            Destroy(collision.gameObject);
            wallHp -= 1;
            bossHB.health = wallHp;
            Debug.Log("El jefe tiene " + wallHp);
            if (wallHp <= 0)
            {
                Debug.Log("Phase 1 completed");
                Destroy(spawners.gameObject);
                phase2.enabled = true;
                phase2Damage.enabled = true;
                preciseShoot.repeatRate = 2.0f;
                gameObject.SetActive(false);
                float bossHp = FindObjectOfType<BossSinMove>().bossHP;
                bossHB.maxHealth = bossHp;
                bossHB.health = bossHp;
            }
        }
    }
    public float WallHP
    {
        get { return wallHp; }

    }

   
}
