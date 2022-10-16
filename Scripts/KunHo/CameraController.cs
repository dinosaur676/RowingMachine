using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{

    public bool isLookForward;
    private GameObject player;
    
    [SerializeField]
    private float distance = 15.0f;

    [SerializeField]
    private float height = 3.0f;
    private Vector3 lookVector;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        lookVector = player.transform.forward;

        if (isLookForward)
            lookVector *= -1;

        Vector3 movePos = player.transform.position + lookVector * distance;
        movePos.y = player.transform.position.y + height;
        transform.position = movePos;


        transform.LookAt(player.transform);
    }


    void FixedUpdate()
    {

    }

}
