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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet")) {
            Destroy(collision.gameObject);
            wallHp -= 1;
            Debug.Log("El jefe tiene " + wallHp);
            if (wallHp <= 0)
            {
                Debug.Log("Phase 1 completed");
                Destroy(spawners.gameObject);
                phase2.enabled = true;
                phase2Damage.enabled = true;
<<<<<<< HEAD
=======
                preciseShoot.repeatRate = 2.0f;
>>>>>>> 5c1f9cfd12306acbe2fbae56078c458c1d844a6d
                gameObject.SetActive(false);

            }
        }
    }

   
}
