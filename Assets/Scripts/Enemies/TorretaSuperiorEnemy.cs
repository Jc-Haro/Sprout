using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaSuperiorEnemy : MonoBehaviour
{

    public float speed = 5f; // The speed at which the object moves
    public float distance = 10f; // The total distance the object will travel

    private float targetPositionX; // The target X position of the object
    private bool movingRight = true; // Flag to track the direction of movement

    private void Start()
    {
        targetPositionX = transform.position.x + distance; // Calculate the target X position
    }

    private void Update()
    {
        // Calculate the movement direction based on the flag
        Vector3 movementDirection = movingRight ? Vector3.right : Vector3.left;

        // Move the object based on the direction and speed
        transform.Translate(movementDirection * speed * Time.deltaTime);

        // Check if the object has reached the target position
        if ((movingRight && transform.position.x >= targetPositionX) ||
            (!movingRight && transform.position.x <= targetPositionX))
        {
            // Reverse the movement direction
            movingRight = !movingRight;

            // Update the target position
            targetPositionX = movingRight ? transform.position.x + distance : transform.position.x - distance;
        }
    }

}
