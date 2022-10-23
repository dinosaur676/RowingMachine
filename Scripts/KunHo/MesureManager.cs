using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesureManager : MonoBehaviour
{
    static private MesureManager instance;

    static public MesureManager Instance
    {
        get
        {
            return instance;
        }
    }

    float distance;
    
    TimeUtil.StopWatch timer;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);

            return;
        }

        instance = GetComponent<MesureManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        distance = 0.0f;
        timer = new TimeUtil.StopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        distance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600;
    }

    public TimeUtil.StopWatch Timer
    {
        get
        {
            return timer;
        }
    }

    public float Distance
    {
        get
        {
            return distance;
        }
    }
}
