using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    Vector3 playerPos;
    // Start is called before the first frame update
    private void Start()
    {
        playerPos = new Vector3(0, 0, -2);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos.x = player.transform.position.x;
         if(player.transform.position.y> transform.position.y + 5 || player.transform.position.y < transform.position.y - 5)
        {
            playerPos.y = player.transform.position.y;
        }
        

        transform.position = playerPos;
    }
}
