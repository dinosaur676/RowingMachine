using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour
{
    Text speedText;
    void Start()
    {
        speedText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = SpeedManager.Instance.BoatSpeed.ToString("F2") + " km/h";
    }
}
