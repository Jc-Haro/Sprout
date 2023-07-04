using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporlHealingOrb : MonoBehaviour
{

    private bool isGrounded = false;
    float fallSpeed = 0.81f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destoyOrb());
        StartCoroutine(DestroyRB());
    }

    void Update()
    {
        if (!isGrounded)
        {
            Vector2 newPos = transform.position;
            newPos.y -= fallSpeed * Time.deltaTime;
            transform.position = newPos; 
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isGrounded)
        {
            isGrounded = true;
        }
    }

    IEnumerator DestroyRB()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    }

    IEnumerator destoyOrb()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }
}
