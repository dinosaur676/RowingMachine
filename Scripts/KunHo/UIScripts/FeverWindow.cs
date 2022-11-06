using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverWindow : MonoBehaviour
{
    private Vector3 originScale;
    private float time = 0.3f;

    Text timeText;
    Text distanceText;
    public void startPopup(float timeSec, float distance)
    {
        originScale = transform.localScale;
        timeText = transform.GetChild(1).GetComponent<Text>();
        distanceText = transform.GetChild(2).GetComponent<Text>();

        timeText.text = timeSec + "초 동안 간거리";
        distanceText.text =((int)(distance * 1000)).ToString("F0") + "M";
        StartCoroutine(startPopupAnim());
        TrainGameManager.Instance.endFeverMode();
        DBManager.Instance.insertDistance((int)timeSec, (int)(distance * 1000));
    }
    IEnumerator startPopupAnim()
    {
        float currentTime = 0;

        while (currentTime <= time)
        {
            transform.localScale = originScale * (currentTime / time);
            currentTime += Time.deltaTime;

            yield return null;
        }

        StartCoroutine(closePopupAnim());
    }

    IEnumerator closePopupAnim()
    {
        yield return new WaitForSeconds(3.0f);

        float currentTime = 0;

        while (currentTime <= time)
        {

            transform.localScale = originScale * (1 - currentTime / time);
            currentTime += Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
