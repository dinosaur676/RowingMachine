using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalorieDTO
{
    System.DateTime date;
    int calorie;
    int time;

    public CalorieDTO()
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
    public int Calorie
    {
        get
        {
            return calorie;
        }
        set
        {
            calorie = value;
        }
    }

    public string getDate()
    {
        return date.Year + "/" + getStr(date.Month) + "/" + getStr(date.Day);
    }

    public override string ToString()
    {
        string strDate = date.Year + "/" + getStr(date.Month) + "/" + getStr(date.Day) + " - " + "00:00:00";
        return "\"" + strDate + "\", " + calorie + ", " + time;
    }

    public string getDay()
    {
        return date.Year + "/" + getStr(date.Month) + "/" + getStr(date.Day);
    }

    private string getStr(int value)
    {
        return value < 10 ? "0" + value : "" + value;
    }
}
