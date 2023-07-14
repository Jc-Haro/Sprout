using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgeaSpawn : MonoBehaviour
{

    [SerializeField] GameObject algeaPrefab;
    [SerializeField] GameObject[] spawnPositions;
    [SerializeField] float startDelay = 0.5f;
    [SerializeField] float shootRate = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateAlgea", startDelay, shootRate);
    }

   
    void GenerateAlgea()
    {
        int randomINdex = Random.Range(0, spawnPositions.Length);
        Instantiate(algeaPrefab, spawnPositions[randomINdex].transform.position, spawnPositions[randomINdex].transform.rotation);
    }
}
