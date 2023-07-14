using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpikeProjectiles : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject spikesProjectile;
    [SerializeField] private GameObject healSpikesProjectile;
    public float projectileForce;
    public float startDelay;
    public float shootRate;
    public float healSpikeProbability;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("ShootSpikes", startDelay, shootRate);
    }

    void ShootSpikes()
    {
        int randomIndex = Random.Range(0, 100);
        GameObject instantiatePrefab = randomIndex <= healSpikeProbability ? healSpikesProjectile : spikesProjectile;
        Vector2 pos = transform.position;
        Vector2 playerPos = player.transform.position;
        GameObject bullet = Instantiate(instantiatePrefab, transform.position, Quaternion.identity);
        Vector2 direction = playerPos - pos;
        bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * projectileForce);
    }
}
