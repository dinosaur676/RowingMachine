using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotCreator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject DotPrefab;

    GameObject content;
    RectTransform parentRect;

    private void Awake()
    {
        content = GameObject.Find("Content");
        parentRect = content.transform.GetComponent<RectTransform>();
    }
    public void createDot(List<CalorieDTO> calorieDTOs, int max)
    {
        parentRect.sizeDelta = new Vector2(300 * calorieDTOs.Count, parentRect.rect.height);

        StartCoroutine(CreateDot(calorieDTOs, max));
    }

    public void createDot(List<RowingDTO> rowingDTOs, int max)
    {
        parentRect.sizeDelta = new Vector2(300 * rowingDTOs.Count, parentRect.rect.height);

        StartCoroutine(CreateDot(rowingDTOs, max));
    }

    IEnumerator CreateDot(List<CalorieDTO> calorieDTOs, int max)
    {
        float parentHeight = parentRect.rect.height;

        for (int i = 0; i < calorieDTOs.Count; ++i)
        {
            GameObject dot = Instantiate(DotPrefab, new Vector3Int(0, 0, 0), Quaternion.identity);
            dot.transform.SetParent(content.transform, false);

            GameObject dotImage = dot.transform.Find("Image").gameObject;
            float y = parentHeight * ((float)calorieDTOs[i].Calorie / max) - parentRect.rect.yMax;
            dotImage.transform.localPosition = new Vector2(dotImage.transform.localPosition.x, y);

            GameObject Date = dot.transform.Find("Date").gameObject;
            Date.GetComponent<Text>().text = calorieDTOs[i].getDate();

            float x = (300 * i) - parentRect.rect.xMax + Date.GetComponent<RectTransform>().sizeDelta.x;
            dot.transform.localPosition = new Vector2(x, dot.transform.localPosition.y);

            yield return null;
        }
    }
    IEnumerator CreateDot(List<RowingDTO> rowingDTOs, int max)
    {
        float parentHeight = parentRect.rect.height;

        for (int i = 0; i < rowingDTOs.Count; ++i)
        {
            GameObject dot = Instantiate(DotPrefab, new Vector3Int(0, 0, 0), Quaternion.identity);
            dot.transform.SetParent(content.transform, false);

            GameObject dotImage = dot.transform.Find("Image").gameObject;
            float y = parentHeight * ((float)rowingDTOs[i].Distance / max) - parentRect.rect.yMax;
            dotImage.transform.localPosition = new Vector2(dotImage.transform.localPosition.x, y);

            GameObject Date = dot.transform.Find("Date").gameObject;
            Date.GetComponent<Text>().text = rowingDTOs[i].getDate();
            

            float x = (300 * i) - parentRect.rect.xMax + Date.GetComponent<RectTransform>().sizeDelta.x;

            dot.transform.localPosition = new Vector2(x, dot.transform.localPosition.y);

            yield return null;
        }
    }
}
