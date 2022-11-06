using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//추가한 부분
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}
//
public class SoundManager : MonoBehaviour
{
  
    static private SoundManager instance = null;

    private AudioSource audioSource;
    private float soundEffectVolume;

    private float prevSEV, prevBGM;


    static public SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
            }

            return instance;
        }
    }

    public float SoundEffectVolume
    {
        get
        {
            return soundEffectVolume;
        }
    }
    
    public float BGMVolume
    {
        get
        {
            return audioSource.volume;
        }
    }

    public void mute(bool isOn)
    {
        if(isOn)
        {
            prevSEV = soundEffectVolume;
            prevBGM = audioSource.volume;

            soundEffectVolume = 0.0f;
            audioSource.volume = 0.0f;
        }
        else
        {
            soundEffectVolume = prevSEV;
            audioSource.volume = prevBGM;
        }
    }

    IEnumerator endSoundEffect(GameObject gameObject)
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        while(source != null && source.isPlaying)
        {
            yield return null;
        }

        if(source != null)
            Destroy(source);

    }

    public void CreateSoundEffect(GameObject gameObject, AudioClip clip)
    {
        gameObject.AddComponent<AudioSource>();
        AudioSource soundEffectAudio = gameObject.GetComponent<AudioSource>();
        soundEffectAudio.clip = clip;
        soundEffectAudio.volume = soundEffectVolume;
        soundEffectAudio.loop = false;
        soundEffectAudio.Play();

        StartCoroutine(endSoundEffect(gameObject));
    }


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundEffectVolume = 0.5f;
        prevSEV = 0.5f;
        prevBGM = 0.5f;
    }

    
    public void setBackGroundMusicVolume(float volume) // 0 ~ 1사이값
    {
        audioSource.volume = Mathf.Clamp(volume, 0.0f, 1.0f);
    }

    public void setSoundEffectVolume(float volume) // 0 ~ 1사이값
    {
        soundEffectVolume = Mathf.Clamp(volume, 0.0f, 1.0f);
    }

    public void setBackGroundMusic(AudioClip clip, bool loop = true)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.time = 0;
        audioSource.Play();
    }

    

}

