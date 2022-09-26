using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField][Range(1f, 100f)] float rotateSpeed = 50f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 front = transform.forward;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * Time.deltaTime * 5.0f, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * Time.deltaTime * 5.0f, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -Time.deltaTime * rotateSpeed, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, Time.deltaTime * rotateSpeed, 0, Space.Self);
        }

    }
}