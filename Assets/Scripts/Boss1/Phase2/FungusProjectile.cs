using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FungusProjectile : MonoBehaviour
{

    [SerializeField] private GameObject[] fungusPhases;
    [SerializeField] private int actualPhase = 0;

    private bool isGrounded = false;

    [SerializeField] private GenerateShoots bulletSpawn;

    [SerializeField] private float fallSpeed;

    bool hasShoot = false;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded)
        {
            Vector2 newPos = transform.position;
            newPos.y -= fallSpeed * Time.deltaTime;
            transform.position = newPos; ;
        }
   
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isGrounded)
        {
<<<<<<< HEAD
=======
            
>>>>>>> 5c1f9cfd12306acbe2fbae56078c458c1d844a6d
            isGrounded = true;
            fungusPhases[actualPhase].SetActive(false);
            fungusPhases[actualPhase + 1].SetActive(true);
            actualPhase++;
<<<<<<< HEAD
            gameObject.GetComponent<BoxCollider2D>().size = fungusPhases[actualPhase].GetComponent<BoxCollider2D>().size; 
            StartCoroutine(ChangePhase());
            
=======
            Vector2 newColliderSize = fungusPhases[actualPhase].GetComponent<BoxCollider2D>().size;
            newColliderSize = ColliderRisezeHandler(newColliderSize);
            gameObject.GetComponent<BoxCollider2D>().size = newColliderSize;
            StartCoroutine(ChangePhase());

>>>>>>> 5c1f9cfd12306acbe2fbae56078c458c1d844a6d
        }
        if (collision.CompareTag("PlayerBullet") && !hasShoot)
        {
            hasShoot = true;
            bulletSpawn.numberOfRounds = actualPhase;
            bulletSpawn.GenerateBullets();
        }
    }

<<<<<<< HEAD
   
=======
    private Vector2 ColliderRisezeHandler(Vector2 newColliderSize)
    {
         
        return new Vector2(newColliderSize.x * fungusPhases[actualPhase].transform.localScale.x, newColliderSize.y * fungusPhases[actualPhase].transform.localScale.y * 2);
    }

>>>>>>> 5c1f9cfd12306acbe2fbae56078c458c1d844a6d

    IEnumerator ChangePhase()
    {
        
        
        yield return new WaitForSeconds(1.5f);
        if (actualPhase < fungusPhases.Length - 1)
        {
            fungusPhases[actualPhase].SetActive(false);
            fungusPhases[actualPhase + 1].SetActive(true);
            actualPhase++;
<<<<<<< HEAD
            gameObject.GetComponent<BoxCollider2D>().size = fungusPhases[actualPhase].GetComponent<BoxCollider2D>().size;
=======
            Vector2 newColliderSize = fungusPhases[actualPhase].GetComponent<BoxCollider2D>().size;
            newColliderSize = ColliderRisezeHandler(newColliderSize);
            gameObject.GetComponent<BoxCollider2D>().size = newColliderSize;
>>>>>>> 5c1f9cfd12306acbe2fbae56078c458c1d844a6d

            StartCoroutine(ChangePhase());
        }
        else
        {
            if (!hasShoot)
            {
                bulletSpawn.numberOfRounds = actualPhase;
                bulletSpawn.GenerateBullets();
            }
            
            
        }
    }
}
