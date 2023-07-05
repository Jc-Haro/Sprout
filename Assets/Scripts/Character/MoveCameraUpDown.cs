using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraUpDown : MonoBehaviour
{
    public GameObject playerCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 adjustPos = playerCam.transform.position;
            adjustPos.y = collision.transform.position.y;
            playerCam.transform.position = adjustPos;
        }
    }
}
