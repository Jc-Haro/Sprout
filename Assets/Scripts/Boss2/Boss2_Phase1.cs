using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Phase1 : MonoBehaviour
{
    [SerializeField] private GenerateShoots shoots;
    public float shootDelay;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private bool hasShoot = false;

    [SerializeField] private Rigidbody2D bulletRigidBody;
   


    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(ShootDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if( !hasShoot && (transform.position.x<minX || transform.position.x>maxX || transform.position.y<minY  || transform.position.y > maxY))
        {
            bulletRigidBody.velocity = Vector2.zero;
            bulletRigidBody.angularVelocity = 0;
            hasShoot = true;
            StopAllCoroutines();
            shoots.GenerateBullets();
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        bulletRigidBody.velocity = Vector2.zero;
        bulletRigidBody.angularVelocity = 0;
        hasShoot = true;
        StopAllCoroutines();
        shoots.GenerateBullets();
    }

 
}
