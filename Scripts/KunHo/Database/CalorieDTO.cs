using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalorieDTO
{
    System.DateTime date;
    int calorie;
    int time;

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
        return date.Year + "/" + date.Month + "/" + date.Day + "\n" + date.Hour + ":" + date.Minute + ":" + date.Second;
    }
}
