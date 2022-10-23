using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    private AudioSource audiosource;
    private Toggle muteButton;
    public GameObject image;

    void Start()
    {
        muteButton = gameObject.GetComponent<Toggle>();
        

    }

    public void muteSound()
    {
        audiosource = SoundManager.Instance.GetComponent<AudioSource>();
        if (!muteButton.isOn)
        {
            
            audiosource.mute = false;
            image.SetActive(false);
        }
        else
        {
            audiosource.mute = true;
            image.SetActive(true);
        }
    }
    
}
