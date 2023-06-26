using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangledProjectileMove : MonoBehaviour
{
    private float speed;
    private readonly float minSpeed = 5.0f;
    private readonly float maxSpeed = 15.0f;
    // Start is called before the first frame update


    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right ); 
    }
}
