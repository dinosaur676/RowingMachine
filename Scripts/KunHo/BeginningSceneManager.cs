using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.setBackGroundMusic(BGMList.Instance.getAudioClip("BeginningSceneBGM"));

    }
}
