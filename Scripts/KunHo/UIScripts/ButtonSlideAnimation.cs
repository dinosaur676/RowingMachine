using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSlideAnimation : MonoBehaviour
{
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

        while(count <= frame)
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

}
