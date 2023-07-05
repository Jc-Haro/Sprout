using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezEnemy : MonoBehaviour
{

    public float speed = 5f; // The speed at which the object moves

    private void Update()
    {
        // Move the object from left to right
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

}
