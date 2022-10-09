using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임 정보 관리하는 게임 매니저
public class TrainGameManager : MonoBehaviour
{
    // 게임정보 표시 UI
    public Text timeText;
    public Text distanceText;
    public Text speedText;
    
    private float distance;  // 거리 km단위

    public GameObject _info_ui;
    private TimeUtil.StopWatch stopWatch;


    void Start()
    {
        _info_ui.SetActive(false);
        distance = 0.0f;

        stopWatch = new TimeUtil.StopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        // 거리 계산
        distance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600 ;
        distanceText.text = "거리 : " + (distance).ToString("F3") + "km";

        TrainUIManager_JeYeon.instance.UpdateSpeedText((float)SpeedManager.Instance.BoatSpeed);

        // 시간을 UI에 표시
        timeText.text = "시간 : " + (int)stopWatch.Time / 60 + "분 "+ (int)stopWatch.Time % 60 + "초";
    }
    
}
