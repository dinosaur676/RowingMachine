using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SharkUI : MonoBehaviour
{
    public Text speedText, timeText, endTimeText;

    public GameObject StartUI, EndUI, InfoUI;

    public void startGameUI()
    {
        changeUI(start: true);
        StartCoroutine(nextUI());
    }
    public void endGameUI()
    {
        changeUI(end: true);
        StartCoroutine(nextUI());
    }


    public void UpdateInfoUI(float surviveTime,float speed)
    {
        speedText.text = "속도 : " + (int)speed;
        timeText.text = "생존 시간 : "+(int)surviveTime;
    }

    IEnumerator nextUI()
    {
        TimeUtil.Timer timer = new TimeUtil.Timer(5.0f);

        while (!timer.isEnd)
        {
            endTimeText.text = "남은시간 : " + (int)timer.Time + "초";
            yield return null;
        }

        if (StartUI.activeSelf)
        {
            changeUI(info: true);
        }
        else if(EndUI.activeSelf)
        {
            LoadingSceneController.LoadScene("Training");
        }
    }

    private void changeUI(bool start = false, bool info = false, bool end = false)
    {
        StartUI.SetActive(start);
        InfoUI.SetActive(info);
        EndUI.SetActive(end);
    }
}
