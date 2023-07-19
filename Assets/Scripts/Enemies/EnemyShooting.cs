using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public AudioSource TurretBulletShot;
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerFocus");
      
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance<12)
        {
            timer += Time.deltaTime;

            if (timer > 1.75f)
            {
                timer = 0;
                shoot();
               
            }
        }

        
    }

    void shoot()
    {
        TurretBulletShot.Play();
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        

    }
}
