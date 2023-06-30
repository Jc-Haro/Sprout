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
        //change to ontrigerrenter2d
        if (Input.GetKeyDown(KeyCode.Q) && actualPhase != 0 && !hasShoot) //collision.CompareTag("PlayerProjectile") && actualPhase != 0)
        {
            hasShoot = true;
            bulletSpawn.numberOfRounds = actualPhase;
            bulletSpawn.GenerateBullets();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isGrounded)
        {
            isGrounded = true;
            Debug.Log("Choco con el piso");
            isGrounded = true;
            fungusPhases[actualPhase].SetActive(false);
            fungusPhases[actualPhase + 1].SetActive(true);
            actualPhase++;
            StartCoroutine(ChangePhase());
        }
        else
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }

    IEnumerator ChangePhase()
    {
        
        
        yield return new WaitForSeconds(1.5f);
        if (actualPhase < fungusPhases.Length - 1)
        {
            fungusPhases[actualPhase].SetActive(false);
            fungusPhases[actualPhase + 1].SetActive(true);
            actualPhase++;
            
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
