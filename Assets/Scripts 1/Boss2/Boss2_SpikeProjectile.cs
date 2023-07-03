using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_SpikeProjectile : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject spikeProjectile;
    private Vector2 destination;
    [SerializeField] private float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        destination = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,destination ,bulletSpeed * Time.deltaTime);
        if(transform.position.x == destination.x || transform.position.y == destination.y)
        {
            Instantiate(spikeProjectile, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
