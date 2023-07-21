using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class FishSpwaner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private GameObject fishPrefab;
    private bool isReadyToAttack = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("InvPlayer")  ) && isReadyToAttack)
        {

            Instantiate(fishPrefab, spawnPos.transform.position, spawnPos.transform.rotation);
            StartCoroutine(SpawnCooldown());
        }
    }

    IEnumerator SpawnCooldown()
    {
        isReadyToAttack = false;
        yield return new WaitForSeconds(3.0f);
        isReadyToAttack = true;
    }
}
