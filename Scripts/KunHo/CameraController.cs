using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    float distance = 4.0f;
    float height = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        Vector3 movePos = player.transform.position + player.transform.forward * distance;
        movePos.y = player.transform.position.y + height;
        transform.position = movePos;


        transform.LookAt(player.transform);
    }


    void FixedUpdate()
    {

    }

}
