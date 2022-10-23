using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWaterEffect : MonoBehaviour
{
    public ParticleSystem waterEffect;
    public GameObject leftWaterPosition;
    public GameObject rightWaterPosition;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

    }
    IEnumerator startEffect(GameObject transformObject)
    {

        ParticleSystem particle = Instantiate(waterEffect, transformObject.transform.position, Quaternion.identity);
        SoundManager.Instance.CreateSoundEffect(particle.gameObject, BGMList.Instance.getAudioClip(NameUtil.SOUND_WATER_IMPACT));

        AudioSource audioSource = particle.gameObject.GetComponent<AudioSource>();

        while(audioSource != null)
        {
            yield return null;
        }

        Destroy(particle.gameObject);
    }

    public void createWaterEffect()
    {
        StartCoroutine(startEffect(leftWaterPosition));
        StartCoroutine(startEffect(rightWaterPosition));
    }
}
