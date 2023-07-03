using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_TP : MonoBehaviour
{

    [SerializeField] private GameObject[] teleportPositions;
    // Start is called before the first frame update
    void Start()
    {
        teleportPositions = GameObject.FindGameObjectsWithTag("TPB2");
        StartCoroutine(bossTP());
    }

    // Update is called once per frame
    
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

        aux = transform.position;
        transform.position = teleportPositions[randomIndex].transform.position;
        teleportPositions[randomIndex].transform.position = aux;
    }
}
