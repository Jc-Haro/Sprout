using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.up * speed * Time.deltaTime;
        if(transform.position.y >7.5 ||transform.position.y< -6.5 || transform.position.x<-11 || transform.position.x> 10)
        {
            Destroy(gameObject);
        }
    }
}
