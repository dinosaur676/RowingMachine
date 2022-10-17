using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임 정보 관리하는 게임 매니저
public class TrainGameManager : MonoBehaviour
{
    public GameObject feverDialog;
    private bool feverMode;


    void Start()
    {
        feverMode = false;

        SoundManager.Instance.setBackGroundMusic(BGMList.Instance.getAudioClip(NameUtil.SOUND_BGM));
    }

    // Update is called once per frame
    void Update()
    {
        if (MesureManager.Instance.Timer.Time % 600 == 0 && !feverMode)
        {
            GameObject gameObject = Instantiate(feverDialog);
            gameObject.transform.SetParent(GameObject.Find("UI").transform, false);
            gameObject.transform.SetAsFirstSibling();
            feverMode = true;
        }

    }
}
