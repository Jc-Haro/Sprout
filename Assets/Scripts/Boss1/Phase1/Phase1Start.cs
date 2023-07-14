using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1Start : MonoBehaviour
{
    [SerializeField] private GameObject limitWalls;
    [SerializeField] private GameObject spawners;
    [SerializeField] private GameObject defensiveWall;
    [SerializeField] private GameObject preciseShoot;
    GameObject playerCam;
    public GameObject mainCam;
    [SerializeField] private GameObject bossUI;
    [SerializeField] private HealthBar bossHB;
    float maxWallHP;

    // Start is called before the first frame update

    private void Start()
    {
        maxWallHP = FindObjectOfType<DefensiveWall>().WallHP;
        bossHB.maxHealth = maxWallHP;
        bossHB.health = maxWallHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerCam = GameObject.FindGameObjectWithTag("PlayerCamera");
     
        if (collision.gameObject.CompareTag("Player"))
        {
            bossUI.SetActive(true);
            limitWalls.SetActive(true);
            spawners.SetActive(true);
            defensiveWall.SetActive(true);
            preciseShoot.SetActive(true);
            mainCam.SetActive(true);
            playerCam.SetActive(false);
            Destroy(gameObject);
        }
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
