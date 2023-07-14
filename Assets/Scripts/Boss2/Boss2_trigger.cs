using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_trigger : MonoBehaviour
{
    // Start is called before the first frame update
  
    [SerializeField] GameObject[] activateOnStart;
    [SerializeField] GameObject[] deactivateOnEnd;
    [SerializeField] GameObject[] activateOnEnd;
    [SerializeField] GameObject playerCam;
    [SerializeField] Tutorial_GrapplingGun newCamera;
    [SerializeField] Camera bossCam;
    public void DeactivateOnEnd()
    {
        
        for (int i = 0; i < deactivateOnEnd.Length; i++)
        {
            deactivateOnEnd[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
    public void ActivateOnEnd()
    {
        for (int i = 0; i < activateOnEnd.Length; i++)
        {
            activateOnEnd[i].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCam.SetActive(false);
            newCamera.m_camera = bossCam;
            for (int i = 0; i < activateOnStart.Length; i++)
            {
                    activateOnStart[i].SetActive(true);
            }
        }
        
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
        }
       
    }
}
