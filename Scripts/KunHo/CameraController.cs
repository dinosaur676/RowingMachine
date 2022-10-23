using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{

    public bool isLookForward;
    private GameObject player;

    
    public float distance = 5.0f;
    
    public float height = 3.0f;
    
    
    private float lerpDistance = 0.0f;

    private Vector3 lookVector;
    private Vector3 movePos;
    
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

        float x = (float)SpeedManager.Instance.BoatSpeed / 7.0f;
        x = x > 1.0f ? 1.0f : x;
        // 최대 거리 * x값 / x의 최대치( 
        lerpDistance = 15.0f * x;
      
        movePos = player.transform.position + lookVector * (distance+lerpDistance);
        movePos.y = player.transform.position.y + height;
        
        transform.position = movePos;
        transform.LookAt(player.transform);
  
    }


    void FixedUpdate()
    {

    }

}
