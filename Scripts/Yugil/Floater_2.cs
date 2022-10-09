using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater_2 : MonoBehaviour  
{
    public GameObject water;
  
   
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, WaveManager.Instance.GetWaveHeight(transform.position.x,water.transform.localScale.x), transform.position.z);
    }
}
