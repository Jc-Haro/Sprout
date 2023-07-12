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
            
            isGrounded = true;
            fungusPhases[actualPhase].SetActive(false);
            fungusPhases[actualPhase + 1].SetActive(true);
            actualPhase++;
            Vector2 newColliderSize = fungusPhases[actualPhase].GetComponent<BoxCollider2D>().size;
            newColliderSize = ColliderRisezeHandler(newColliderSize);
            gameObject.GetComponent<BoxCollider2D>().size = newColliderSize;
            StartCoroutine(ChangePhase());

        }
        if (collision.CompareTag("PlayerBullet") && !hasShoot)
        {
            hasShoot = true;
            bulletSpawn.numberOfRounds = actualPhase;
            bulletSpawn.GenerateBullets();
        }
    }

    private Vector2 ColliderRisezeHandler(Vector2 newColliderSize)
    {
         
        return new Vector2(newColliderSize.x * fungusPhases[actualPhase].transform.localScale.x, newColliderSize.y * fungusPhases[actualPhase].transform.localScale.y * 2);
    }


    IEnumerator ChangePhase()
    {
        
        
        yield return new WaitForSeconds(1.5f);
        if (actualPhase < fungusPhases.Length - 1)
        {
            fungusPhases[actualPhase].SetActive(false);
            fungusPhases[actualPhase + 1].SetActive(true);
            actualPhase++;
            Vector2 newColliderSize = fungusPhases[actualPhase].GetComponent<BoxCollider2D>().size;
            newColliderSize = ColliderRisezeHandler(newColliderSize);
            gameObject.GetComponent<BoxCollider2D>().size = newColliderSize;

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
