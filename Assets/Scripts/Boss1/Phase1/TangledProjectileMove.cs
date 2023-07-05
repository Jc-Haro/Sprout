using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangledProjectileMove : MonoBehaviour
{
    private float speed;
    private readonly float minSpeed = 7.0f;
    private readonly float maxSpeed = 12.0f;
    // Start is called before the first frame update


    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        StartCoroutine(SelfDestoyProjectile());

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right ); 
    }

    IEnumerator SelfDestoyProjectile()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
