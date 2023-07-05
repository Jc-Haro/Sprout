using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangleSpawner : MonoBehaviour
{
    public GameObject projectile;
    public GameObject healingProjectile;
    [SerializeField] private float shootCadency;
    [SerializeField] private float shootStart;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    public int healProbability;


    private void Start()
    {
        InvokeRepeating("SpwanTangleProjectile", shootStart, shootCadency);
    }


    void SpwanTangleProjectile()
    {
        if (Random.Range(0, 100) <= healProbability)
        {
            Vector3 generationPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            Instantiate(healingProjectile, generationPosition, gameObject.transform.rotation);
        }
        else {
            Vector3 generationPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            Instantiate(projectile, generationPosition, gameObject.transform.rotation);
        }
       
    }

}
