using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGraphValue : MonoBehaviour
{
    public GameObject textPrefab;

    void Start()
    {
        GameObject exerciseGraph = GameObject.Find("ExerciseGraph");
        RectTransform GraphRectTransform = exerciseGraph.GetComponent<RectTransform>();

        Vector3 graphPosition = exerciseGraph.transform.localPosition;
        float x = graphPosition.x - (GraphRectTransform.rect.width / 2) - (GetComponent<RectTransform>().rect.width / 2);

        Vector3 newLocalPosition = graphPosition;
        newLocalPosition.x = x;
        transform.localPosition = newLocalPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createValue(int lineCount, int min, int interval)
    {
        StartCoroutine(CreateValue(lineCount, min, interval));
    }

    IEnumerator CreateValue(int lineCount, int min, int interval)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        float height = rectTransform.rect.height;

        for (int i = 0; i < lineCount + 1; ++i)
        {
            GameObject text = null;

            if (transform.childCount < lineCount + 1)
                text = Instantiate(textPrefab, new Vector3Int(0, 0, 0), Quaternion.identity);
            else
                text = transform.GetChild(i).gameObject;

            RectTransform childRect = text.GetComponent<RectTransform>();
            childRect.sizeDelta = new Vector2(rectTransform.rect.width - 20, 30);

            text.transform.SetParent(transform, false);
            text.transform.localPosition = new Vector3(-rectTransform.rect.width / 2, ((height / lineCount) * i) - height / 2, 0);
            text.GetComponent<Text>().text = "" + (min + (interval * i));
            

            yield return null;
        }
    }
}
