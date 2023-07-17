using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss2_TP : MonoBehaviour
{
    public AudioSource TeleportingSound;
    [SerializeField] private GameObject[] teleportPositions;
    [SerializeField] private GameObject[] platformPositions;
    [SerializeField] Color color;
    [SerializeField] Color staticColor;
    private int maxUnactivePlatforms = 0;
    int platformChanges = 0;
    bool turnOFF_Platforms = false;
    // Start is called before the first frame update
    void Start()
    {
        staticColor = platformPositions[0].GetComponent<SpriteRenderer>().color;
        teleportPositions = GameObject.FindGameObjectsWithTag("TPB2");
        StartCoroutine(bossTP());
        StartCoroutine(PlatformDelay());
    }

    // Update is called once per frame
    private void Update()
    {
        if (turnOFF_Platforms)
        {
            TurnOFF_Platforms();
        }
    }
    IEnumerator bossTP()
    {
        float randomWaitTime = Random.Range(2.0f, 6.0f);
        yield return new WaitForSeconds(randomWaitTime);
        switchPositions();
        StartCoroutine(bossTP());

    }

    private void switchPositions()
    {
        int randomIndex = Random.Range(0, teleportPositions.Length);
        Vector2 aux;
        TeleportingSound.Play();
        aux = transform.position;
        transform.position = teleportPositions[randomIndex].transform.position;
        teleportPositions[randomIndex].transform.position = aux;
    }
    void TurnOFF_Platforms()
    {
        for (int i = 0; i < maxUnactivePlatforms; i++)
        {
            color.a -= 0.3f * Time.deltaTime;
            if (color.a <= 0)
            {
                platformPositions[i].SetActive(false);
            }
            else
            { 
                platformPositions[i].GetComponent<SpriteRenderer>().color = color;
            }
            
        }
        
    } 
    public void TurnOn_Platforms()
    {

        for (int i = 0; i < platformPositions.Length; i++)
        {
            platformPositions[i].SetActive(true);
           
           
            platformPositions[i].GetComponent<SpriteRenderer>().color = staticColor;
        }
        Reshuffle(platformPositions);
    }

    void SwitchActivePlatforms()
    {
       
        if (platformChanges > 2 && maxUnactivePlatforms<3)
        {
            maxUnactivePlatforms++;
            platformChanges = 0;
            
        }
        if(maxUnactivePlatforms < 3 && maxUnactivePlatforms  > 0)
        {
            turnOFF_Platforms = true;
            color = staticColor;
        }
    }

    IEnumerator PlatformDelay()
    {
        yield return new WaitForSeconds(7.0f);
        platformChanges++;
        TurnOn_Platforms();
        SwitchActivePlatforms();
        StartCoroutine(PlatformDelay());
    }

    void Reshuffle(GameObject[] platforms)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < platforms.Length; t++)
        {
            GameObject tmp = platforms[t];
            int r = Random.Range(t, platforms.Length);
            platforms[t] = platforms[r];
            platforms[r] = tmp;
        }
    }

  
}
