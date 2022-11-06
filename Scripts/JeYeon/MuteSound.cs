using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    private Toggle muteButton;
    public GameObject image;

    void Start()
    {
        muteButton = gameObject.GetComponent<Toggle>();
        

    }

    public void muteSound()
    {
        SoundManager.Instance.mute(muteButton.isOn);

        if (!muteButton.isOn)
        {
            image.SetActive(false);
        }
        else
        {
            image.SetActive(true);
        }
    }
    
}
