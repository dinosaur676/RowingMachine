using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverDialog : MonoBehaviour
{
    // Start is called before the first frame update
    Image timeProgressbar;
    Image distanceProgressBar;

    float speed;
    float distance;
    float currentDistance;
    float timeSec;
    TimeUtil.Timer timer;

    void Start()
    {
        timeProgressbar = transform.Find("TimeProgressBar").GetComponent<Image>();
        distanceProgressBar = transform.Find("DistanceProgressBar").GetComponent<Image>();


        timeSec = 5.0f; //Random.Range(300.0f, 480.0f);
        speed = Random.Range(3.0f, 6.0f);
        timer = new TimeUtil.Timer(timeSec);
        distance = speed / 3600 * timeSec;
        currentDistance = 0.0f ;
    }

    // Update is called once per frame
    void Update()
    {
        timeProgressbar.fillAmount = timer.Time / timeSec;
        distanceProgressBar.fillAmount = currentDistance / distance;

        currentDistance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600;

        if (timer.isEnd || currentDistance >= distance)
        {
            Destroy(transform.parent.gameObject);
        }
        
    }
}
