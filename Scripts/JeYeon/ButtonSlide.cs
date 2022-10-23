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
    private float currentTime = 0;

    public void startSlide(int y)
    {
        transform.gameObject.SetActive(true);
        this.y = y;
        StartCoroutine(startSlideAnim());
    }

    IEnumerator startSlideAnim()
    {

        startPos = transform.GetComponent<RectTransform>().localPosition;
        endPos = new Vector3(0, -1 * movePosition * y, 0);
        
        
        while (currentTime < lerpTime)
        {
            currentTime += Time.deltaTime;
            
            transform.GetComponent<RectTransform>().localPosition = Vector3.Lerp(startPos, endPos,
                currentTime / lerpTime);

            
            yield return null;
        }
        currentTime = 0;
    }
    
    public void closeSlide()
    {
        StartCoroutine(closeSlideAnim());
    }
    IEnumerator closeSlideAnim()
    {
        startPos = transform.GetComponent<RectTransform>().localPosition;
        endPos = new Vector3(0, 0, 0);


        while (currentTime < lerpTime)
        {
            currentTime += Time.deltaTime;

            transform.GetComponent<RectTransform>().localPosition = Vector3.Lerp(startPos, endPos,
                currentTime / lerpTime);

            
            yield return null;
        }
        currentTime = 0;
        transform.gameObject.SetActive(false);
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
