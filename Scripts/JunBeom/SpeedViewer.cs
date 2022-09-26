using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedViewer : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 0.0f;

    public float minSpeedNeedle;
    public float maxSpeedNeedle;

    [Header("UI")]
    public Text speedlabel;
    public RectTransform Needle;

    private float speed = 0.0f;
    private void Update()
    {
       // speed = target.velocity.magnitude * 3.6f;// 속도값인데 모르겟네?

        if (speedlabel != null)
            speedlabel.text = ((int)speed) + "km/h";
        if (Needle != null)
            Needle.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedNeedle, maxSpeedNeedle, speed / maxSpeed));
    }
}
