using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowingDTO
{
    System.DateTime date;
    int distance;
    int time;
    bool isSuccess;

    public System.DateTime Date
    {
        get
        {
            return date;
        }
        set
        {
            date = value;
        }
    }

    public int Distance
    {
        get
        {
            return distance;
        }
        set
        {
            distance = value;
        }
    }

    public int Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
        }
    }

    public bool IsSuccess
    {
        get
        {
            return isSuccess;
        }
        set
        {
            isSuccess = value;
        }
    }

    public string getDate()
    {
        return date.Year + "/" + date.Month + "/" + date.Day + "\n" + date.Hour + ":" + date.Minute + ":" + date.Second;
    }
}
