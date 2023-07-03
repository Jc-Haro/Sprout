using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusDrop : MonoBehaviour
{

    [SerializeField] private GameObject[] numberOfFungus;
   
    bool isFungusOnCooldown = false;

    [SerializeField] private float shootDelay;
    [SerializeField] private float shootSpeedAugment;
    [SerializeField] private float maxShootSpeed;

    [SerializeField] private GameObject fungusProjectile;

    [SerializeField] private BossSinMove mainBoss;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfFungus = GameObject.FindGameObjectsWithTag("Fungus");
        if (numberOfFungus.Length < 4 && !isFungusOnCooldown && mainBoss.startMove)
        {
            Instantiate(fungusProjectile, transform.position, transform.rotation);
            isFungusOnCooldown = true;
            StartCoroutine(fungusCooldown());
        }
    }

    IEnumerator fungusCooldown()
    {
        yield return new WaitForSeconds(shootDelay);
        if (shootDelay > maxShootSpeed)
        {
            shootDelay -= shootSpeedAugment;
        }
        isFungusOnCooldown = false;
    }
}
