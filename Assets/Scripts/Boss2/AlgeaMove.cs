using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgeaMove : MonoBehaviour
{
    private float speed;
    private readonly float minSpeed = 7.0f;
    private readonly float maxSpeed = 12.0f;
    private float collitionLifeTime = 2.0f;
    // Start is called before the first frame update


    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        StartCoroutine(SelfDestoyProjectile());

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right);
    }

    IEnumerator SelfDestoyProjectile()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        collitionLifeTime -= 1 * Time.deltaTime;
        if (collitionLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
