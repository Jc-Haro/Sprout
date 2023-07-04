using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreciseShoot : MonoBehaviour
{
    [SerializeField] float topSpawnPos;
    [SerializeField] private float leftSpawnPos;
    [SerializeField] private float rightSpawnPos;
    private Vector2 SpawnPosition;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GeneratePreciseShooot", 6.0f, 3.0f);

    }

    // Update is called once per frame

    private void GeneratePreciseShooot()
    {
        int randomIndex = Random.Range(0, 100);
       

        if (randomIndex > 66)
        {
            SpawnPosition.y = topSpawnPos;
            SpawnPosition.x = player.transform.position.x;
            Instantiate(bulletPrefab, SpawnPosition, Quaternion.Euler(new Vector3(0,0,-90)));
        }
        else if (randomIndex > 33)
        {
            
            SpawnPosition.y = player.transform.position.y;
            SpawnPosition.x = leftSpawnPos;
            Instantiate(bulletPrefab, SpawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else
        {
            SpawnPosition.y = player.transform.position.y;
            SpawnPosition.x = rightSpawnPos;
            Instantiate(bulletPrefab, SpawnPosition, Quaternion.Euler(new Vector3(0, 180, 0)));
        }
    }
}
