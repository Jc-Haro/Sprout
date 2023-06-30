using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletOutOfCamera : MonoBehaviour
{

    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (OutOfBounds())
        {
            Destroy(gameObject);
        }

      
    }

    private bool OutOfBounds()
    {
        return transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY;
    }


}
