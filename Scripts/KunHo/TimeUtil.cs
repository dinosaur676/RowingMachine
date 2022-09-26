using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeUtil
{ 
    public class Timer
    {
        private float start_time;
        private float seconds;

        public float Time
        {
            get
            {
                return TimeManager.Instance.Total_time - start_time;
            }
        }

        public bool isEnd
        {
            get
            {
                return Time > seconds;
            }
        }
        public Timer(float seconds)
        {
            start_time = TimeManager.Instance.Total_time;
            this.seconds = seconds;
        }
    }

    public class StopWatch
    {
        private List<float> record;
        private float start_time;

        public float Time
        {
            get
            {
                return TimeManager.Instance.Total_time - start_time;
            }
        }

        public StopWatch()
        {
            start_time = TimeManager.Instance.Total_time;
            record = new List<float>();
        }

        public void Record()
        {
            record.Add(TimeManager.Instance.Total_time - start_time);
        }

        public float[] getRecords()
        {
            return record.ToArray();
        }

    }
      
}