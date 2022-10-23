using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonAnimation : MonoBehaviour
{
    Toggle toggle;
    [SerializeField]
    Sprite idle;

    [SerializeField]
    Sprite selected;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
            toggle.image.sprite = selected;
        else
            toggle.image.sprite = idle;
    }
}
