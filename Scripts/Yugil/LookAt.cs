using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookAt : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform target;
    
    //[SerializeField] float turnSpeed = 5f;
    // Start is called before the first frame update
    private void Start()
    {
       
    }

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
  
        transform.LookAt(target);
        nav.SetDestination(target.position);
    }
    /*private void TargetRotate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }*/
}
