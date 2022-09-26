using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater_2 : MonoBehaviour  
{
    public GameObject water;
  
   
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, WaveManager.instance.GetWaveHeight(transform.position.x,water.transform.localScale.x), transform.position.z);
        /*float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;

            rigidBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
            rigidBody.AddForce(displacementMultiplier * -rigidBody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidBody.AddTorque(displacementMultiplier * -rigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        */
    }
}
