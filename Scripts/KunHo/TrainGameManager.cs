using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임 정보 관리하는 게임 매니저
public class TrainGameManager : MonoBehaviour
{
    public GameObject feverDialog;
    private bool feverMode;
    private Text distanceAndTimeText;
    private float distance;  // 거리 km단위
    private TimeUtil.StopWatch stopWatch;


    void Start()
    {
        feverMode = false;
        distance = 0.0f;
        distanceAndTimeText = GameObject.Find("Distance&Time").transform.Find("Text").GetComponent<Text>();


        stopWatch = new TimeUtil.StopWatch();
        SoundManager.Instance.setBackGroundMusic(BGMList.Instance.getAudioClip(NameUtil.SOUND_BGM));
    }

    // Update is called once per frame
    void Update()
    {
        // 거리 계산
        distance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600;

        if(((int)stopWatch.Time / 5) % 2 == 0)
        {
            distanceAndTimeText.text = "거리 : " + (distance).ToString("F3") + "km";
        }
        else
        {
            distanceAndTimeText.text = "시간 : " + (int)stopWatch.Time / 60 + "분 " + (int)stopWatch.Time % 60 + "초";
        }

        if ((int)stopWatch.Time % 600 == 0 && !feverMode)
        {
            GameObject gameObject = Instantiate(feverDialog);
            gameObject.transform.SetParent(GameObject.Find("UI").transform, false);
            gameObject.transform.SetAsFirstSibling();
            feverMode = true;
        }

    }
}
