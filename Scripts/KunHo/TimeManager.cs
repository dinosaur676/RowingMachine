using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    static private TimeManager instance = null;
    // Start is called before the first frame update

    float total_time;

    static public TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("UtilManager").GetComponent<TimeManager>();
            }

            return instance;
        }
    }

    public float Total_time
    {
        get
        {
            return total_time;
        }
    }

    void Start()
    {
        total_time = 0.0f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        total_time += Time.deltaTime;
    }
}
