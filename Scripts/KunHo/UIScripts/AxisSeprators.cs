using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisSeprators : MonoBehaviour
{
    public GameObject LinePrefab;

    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLine(int lineCount)
    {
        StartCoroutine(CreateLineX(lineCount));
    }

    IEnumerator CreateLineX(int lineCount)
    {
        GameObject content = transform.parent.gameObject;
        RectTransform parentRect = content.GetComponent<RectTransform>();
        float parentHeight = parentRect.rect.height;


        for(int i = 0; i < lineCount - 1; ++i)
        {
            GameObject line = Instantiate(LinePrefab, new Vector3Int(0, 0, 0), Quaternion.identity);

            RectTransform rectTransform = line.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(parentRect.rect.width, 4);

            line.transform.SetParent(content.transform, false);
            line.transform.localPosition = new Vector3(parentRect.rect.center.x, ((parentHeight / lineCount) * (i + 1)) - parentHeight, 0);
            line.transform.SetAsFirstSibling();

            yield return null;
        }
    }
}
