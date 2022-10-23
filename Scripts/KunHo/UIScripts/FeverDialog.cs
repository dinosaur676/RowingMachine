using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverDialog : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Image timeProgressbar;

    [SerializeField]
    Image timeIcon;

    [SerializeField]
    Text text;

    [SerializeField]
    GameObject resultWindow;

    float distance;
    float timeSec;
    TimeUtil.Timer timer;

    void Start()
    {
        timeSec = 5.0f; //Random.Range(300.0f, 480.0f);
        timer = new TimeUtil.Timer(timeSec);
        distance = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeProgressbar.fillAmount = timer.Time / timeSec;

        distance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600;

        float remainTime = timeSec - timer.Time;
        text.text = "남은시간 : " + remainTime.ToString("F1");

        float x = timeProgressbar.rectTransform.sizeDelta.x * timeProgressbar.rectTransform.localScale.x;
        float positionX = x * timeProgressbar.fillAmount - (x / 2);

        timeIcon.rectTransform.localPosition = new Vector3(positionX, timeIcon.rectTransform.localPosition.y,
            timeIcon.rectTransform.localPosition.z);

        if (timer.isEnd)
        {
            GameObject window = Instantiate(resultWindow, transform.parent, false);
            window.GetComponent<FeverWindow>().startPopup(timeSec, distance);

            Destroy(gameObject);
        }
    }
}
