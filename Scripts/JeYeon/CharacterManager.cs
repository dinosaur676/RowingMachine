using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public AudioSource _audio;
    public AudioClip clip;
    public ParticleSystem waterEffect;
    public GameObject LeftPosition;
    public GameObject RightPosition;

    private ParticleSystem RightWater;
    private ParticleSystem LeftWater;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "water")
        {
            _audio.PlayOneShot(clip);
            
            RightWater = Instantiate(waterEffect, RightPosition.transform.position,Quaternion.identity);
            LeftWater = Instantiate(waterEffect, LeftPosition.transform.position, Quaternion.identity);
        }
        if (RightWater != null && LeftWater != null)
        {
            Destroy(RightWater.gameObject, 3.0f);
            Destroy(LeftWater.gameObject, 3.0f);
        }
    }
    
}
