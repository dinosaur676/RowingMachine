using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임 정보 관리하는 게임 매니저
public class TrainGameManager : MonoBehaviour
{
    static private TrainGameManager instance;
    static public TrainGameManager Instance
    {
        get
        {
            return instance;
        }
    }
    public GameObject feverDialog;
    private bool feverMode;
    private TimeUtil.Timer timer;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);

            return;
        }

        instance = GetComponent<TrainGameManager>();
    }

    void Start()
    {
        timer = new TimeUtil.Timer(Random.Range(480.0f, 600.0f));
        feverMode = false;

        SoundManager.Instance.setBackGroundMusic(BGMList.Instance.getAudioClip(NameUtil.SOUND_BGM));
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isEnd && !feverMode)
        {
            GameObject gameObject = Instantiate(feverDialog);
            gameObject.transform.SetParent(GameObject.Find("UI").transform, false);
            gameObject.transform.SetAsFirstSibling();
            feverMode = true;
        }

    }

    public void endFeverMode()
    {
        timer = new TimeUtil.Timer(Random.Range(480.0f, 600.0f));

        feverMode = false;
    }
}
