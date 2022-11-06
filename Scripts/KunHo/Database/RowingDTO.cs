using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowingDTO
{
    System.DateTime date;
    int distance;
    int time;
    bool isSuccess;
    public RowingDTO()
    {
        date = System.DateTime.Now;
    }

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
        return date.Year + "/" + getStr(date.Month) + "/" + getStr(date.Day) + "\n" + getStr(date.Hour) + ":" + getStr(date.Minute) + ":" + getStr(date.Second);
    }

    public override string ToString()
    {
        string strDate = date.Year + "/" + getStr(date.Month) + "/" + getStr(date.Day) + " - " + getStr(date.Hour) + ":" + getStr(date.Minute) + ":" + getStr(date.Second);
        return "\"" + strDate + "\", " + time + ", " + distance + ", " + "1";
    }

    private string getStr(int value)
    {
        return value < 10 ? "0" + value : "" + value;
    }
}
