using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    static private SpeedManager instance = null;

    double boatSpeed;
    double goalBoatSpeed;
    double stopBoatSpeed;
    float currentTime;
    float resetTime;
    bool stop;

    double m, y;
    


    static public SpeedManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("UtilManager").GetComponent<SpeedManager>();
            }

            return instance;
        }
    }

    public double BoatSpeed
    {
        get
        {
            return boatSpeed;
        }
    }

    public double GoalBoatSpeed
    {
        set
        {
            goalBoatSpeed = value;
            getEquation();
            currentTime = 0.0f;
            resetTime = 0.0f;
            stop = false;
        }
    }

    public bool isStop
    {
        get
        {
            return stop;
        }
    }

    private void Start()
    {
        goalBoatSpeed = 0.0;
        stopBoatSpeed = 0.0;
        boatSpeed = 0.0;
        currentTime = 0.0f;
        resetTime = 0.0f;
        m = y = 0.0;
        stop = false;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(stop)
        {
            boatSpeed = getSpeedStopBoat();
            if(boatSpeed <= 0.0)
            {
                resetTime = 0.0f;
            }
        }
        else
        {
            resetTime += Time.deltaTime;

            if (resetTime >= 0.6)
            {
                stop = true;
                currentTime = 0.0f;
                stopBoatSpeed = boatSpeed;
                return;
            }

            boatSpeed = getSpeedCurrentTime();
        }
    }

    private void getEquation()
    {
        m = (goalBoatSpeed - boatSpeed) / 2;
        y = boatSpeed;
    }

    private double getSpeedCurrentTime()
    {
        return m * currentTime + y;
    }

    private double getSpeedStopBoat()
    {
        double output = -1 * (currentTime * currentTime) + stopBoatSpeed;

        output = output <= 0.0 ? 0.0 : output;

        return output;
    }


}
