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

    [SerializeField] private GameObject[] fungusProjectile;

    [SerializeField] private BossSinMove mainBoss;

    [SerializeField] private int goodFungusProbability;


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
            int fungusChoice = Random.Range(0,100)<= goodFungusProbability? 1 : 0;
            Debug.Log(fungusChoice);
            Instantiate(fungusProjectile[fungusChoice], transform.position, transform.rotation);
            isFungusOnCooldown = true;
            StartCoroutine(FungusCooldown());
        }
    }

    IEnumerator FungusCooldown()
    {
        yield return new WaitForSeconds(shootDelay);
        if (shootDelay > maxShootSpeed)
        {
            shootDelay -= shootSpeedAugment;
        }
        isFungusOnCooldown = false;
    }
}
