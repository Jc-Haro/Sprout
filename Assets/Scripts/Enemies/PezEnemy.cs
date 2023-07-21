using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezEnemy : MonoBehaviour
{



    public float horizontalSpeed = 3f;   // Speed of horizontal movement
    public float verticalSpeed = 3f;     // Speed of vertical movement
    public float horizontalDuration = 3f; // Duration of horizontal movement
    public float verticalDuration = 3f;   // Duration of vertical movement

    private Vector3 initialPosition;      // Initial position of the object

    private void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MovementCoroutine());
    }

    private System.Collections.IEnumerator MovementCoroutine()
    {
        while (true)
        {
            // Move horizontally from left to right
            float horizontalTimeElapsed = 0f;
            while (horizontalTimeElapsed < horizontalDuration)
            {
                transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
                horizontalTimeElapsed += Time.deltaTime;
                yield return null;
            }

            // Move vertically
            float verticalTimeElapsed = 0f;
            while (verticalTimeElapsed < verticalDuration)
            {
                transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
                verticalTimeElapsed += Time.deltaTime;
                yield return null;
            }

            // Move horizontally for 3 seconds
            horizontalTimeElapsed = 0f;
            while (horizontalTimeElapsed < horizontalDuration)
            {
                transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
                horizontalTimeElapsed += Time.deltaTime;
                yield return null;
            }

            // Return to the ground
            Destroy(gameObject);
        }
    }







}

