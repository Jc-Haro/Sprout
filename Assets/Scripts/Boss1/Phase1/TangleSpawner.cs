using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangleSpawner : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] private float shootCadency;
    [SerializeField] private float shootStart;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private void Start()
    {
        InvokeRepeating("SpwanTangleProjectile", shootStart, shootCadency);
    }


    void SpwanTangleProjectile()
    {
        Vector3 generationPosition = new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY),0);
        Instantiate(projectile,generationPosition, gameObject.transform.rotation);
    }

}
