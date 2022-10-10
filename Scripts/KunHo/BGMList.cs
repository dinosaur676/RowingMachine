using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMList : MonoBehaviour
{
    static private BGMList instance = null;

    static public BGMList Instance
    {
        get
        {
            if(instance == null)
                instance = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BGMList>();

            return instance;
        }
    }

    [System.Serializable]
    private struct BGM
    {
        public string name;
        public AudioClip clip;
    }

    [SerializeField]
    private BGM[] list;

    public AudioClip getAudioClip(string name)
    {
        for(int index = 0; index < list.Length; ++index)
        {
            if (list[index].name == name)
                return list[index].clip;
        }

        return null;
    }

    
}
