using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlide : MonoBehaviour
{
    private float movePosition = 180.0f;

    private int y;

    private Vector3 startPos;
    private Vector3 endPos;
    private float lerpTime = 0.5f;

    Coroutine startCoroutine = null;
    Coroutine closeCoroutine = null;

    public void startSlide(int y)
    {
        transform.gameObject.SetActive(true);
        this.y = y;

        if (transform.gameObject.activeSelf)
        {
            if (closeCoroutine != null)
                StopCoroutine(closeCoroutine);
            startCoroutine = StartCoroutine(startSlideAnim());
        }
    }

    IEnumerator startSlideAnim()
    {
        float currentTime = 0.0f;
        startPos = transform.GetComponent<RectTransform>().localPosition;
        endPos = new Vector3(0, -1 * movePosition * y, 0);
        
        
        while (currentTime < lerpTime)
        {
            transform.GetComponent<RectTransform>().localPosition = Vector3.Lerp(startPos, endPos,
                currentTime / lerpTime);

            currentTime += Time.deltaTime;

            yield return null;
        }

        startCoroutine = null;
    }
    
    public void closeSlide()
    {
        if (transform.gameObject.activeSelf)
        {
            if (startCoroutine != null)
                StopCoroutine(startCoroutine);
            closeCoroutine = StartCoroutine(closeSlideAnim());
        }


    }
    IEnumerator closeSlideAnim()
    {
        float currentTime = 0.0f;
        startPos = transform.GetComponent<RectTransform>().localPosition;
        endPos = new Vector3(0, 0, 0);


        while (currentTime < lerpTime)
        {
            transform.GetComponent<RectTransform>().localPosition = Vector3.Lerp(startPos, endPos,
                currentTime / lerpTime);

            currentTime += Time.deltaTime;

            yield return null;
        }

        closeCoroutine = null;
        transform.gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        transform.GetComponent<RectTransform>().localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void OnDisable()
    {
        transform.GetComponent<RectTransform>().localPosition = new Vector3(0, -1 * movePosition * y, 0);
    }



    /*
    private float moveDistance = 180.0f;
    private const int frame = 60;
    private int y;

    public void Open(int y)
    {
        transform.gameObject.SetActive(true);
        this.y = y;
        StartCoroutine(openAnimation());
    }

    private IEnumerator openAnimation()
    {
        int count = 0;
        RectTransform rectTransform = GetComponent<RectTransform>();

        while (count <= frame)
        {

            float posX = rectTransform.localPosition.x;
            float posZ = rectTransform.localPosition.z;
            float posY = -1 * moveDistance * y * count / frame;

            rectTransform.localPosition = new Vector3(posX, posY, posZ);
            count += 1;

            yield return null;
        }
    }
    public void Close()
    {
        StartCoroutine(closeAnimation());
    }

    private IEnumerator closeAnimation()
    {
        int count = 0;
        RectTransform rectTransform = GetComponent<RectTransform>();
        float PrevY = rectTransform.localPosition.y;

        while (count <= frame)
        {

            float posX = rectTransform.localPosition.x;
            float posZ = rectTransform.localPosition.z;
            float posY = moveDistance * y * count / frame;
            posY += PrevY;

            rectTransform.localPosition = new Vector3(posX, posY, posZ);
            count += 1;

            yield return null;
        }

        transform.gameObject.SetActive(false);
    }
    */
}
