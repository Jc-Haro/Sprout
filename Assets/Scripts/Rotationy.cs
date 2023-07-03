using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotationy : MonoBehaviour
{
    public float RotateSpeed;
    public float speed;
    public Transform pos1;
    public Transform pos2;
    bool turnback;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.Transform.Rotate(0, 0, RotateSpeed);
        gameObject.transform.Rotate(0, 0, RotateSpeed);

        if (transform.position.y >= pos1.position.y)
        {
            turnback = true;
        }
        if (transform.position.y <= pos2.position.y)
        {
            turnback = false;
        }
        if (turnback)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);
        }
    }
}