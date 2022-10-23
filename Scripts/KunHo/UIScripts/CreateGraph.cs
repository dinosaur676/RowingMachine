using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateGraph : MonoBehaviour
{

    int lineCount = 10;

    private int[] testList = { 11, 25, 71, 80, 64, 30, 37, 57, 67, 77 };
    [SerializeField]
    private GameObject axisSeparator;

    [SerializeField]
    private GameObject showGraphValue;

    [SerializeField]
    private GameObject dotCreator;

    [SerializeField]
    private Toggle calorie;
    
    [SerializeField]
    private Toggle distance;

    [SerializeField]
    private GameObject content;


    private void Awake()
    {
        axisSeparator.GetComponent<AxisSeprators>().CreateLine(lineCount);  
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int GetMax(int value)
    {
        if (value < 10)
            return 10;

        int exponent = (int)Mathf.Log10(value);
        int pow = (int)Mathf.Pow(10, exponent);
        int div = value / pow;
        int max = (div + 1) * pow;

        return max;
    }

    public void onRadio()
    {
        int max = int.MinValue;
        if (content.transform.childCount > 0)
        {
            for (int i = 0; i < content.transform.childCount; ++i)
            {
                Destroy(content.transform.GetChild(i).gameObject);
            }
        }

        if (calorie.isOn)
        {
            List<CalorieDTO> calorieDTOs = DBManager.Instance.getCalories();

            for (int i = 0; i < calorieDTOs.Count; ++i)
            {
                if (calorieDTOs[i].Calorie > max)
                    max = calorieDTOs[i].Calorie;
            }

            max = GetMax(max);


            showGraphValue.GetComponent<ShowGraphValue>().createValue(lineCount, 0, max / lineCount);
            dotCreator.GetComponent<DotCreator>().createDot(calorieDTOs, max);
        }
        else if(distance.isOn)
        {
            List<CalorieDTO> calorieDTOs = new List<CalorieDTO>();

            for (int i = 0; i < calorieDTOs.Count; ++i)
            {
                if (calorieDTOs[i].Calorie > max)
                    max = calorieDTOs[i].Calorie;
            }

            max = GetMax(max);

            showGraphValue.GetComponent<ShowGraphValue>().createValue(lineCount, 0, max / lineCount);
            dotCreator.GetComponent<DotCreator>().createDot(calorieDTOs, max);
        }
    }
}
