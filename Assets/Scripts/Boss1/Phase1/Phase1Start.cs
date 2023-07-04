using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1Start : MonoBehaviour
{
    [SerializeField] private GameObject limitWalls;
    [SerializeField] private GameObject spawners;
    [SerializeField] private GameObject defensiveWall;
    [SerializeField] private GameObject preciseShoot;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            limitWalls.SetActive(true);
            spawners.SetActive(true);
            defensiveWall.SetActive(true);
            preciseShoot.SetActive(true);
            Destroy(gameObject);
        }
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
