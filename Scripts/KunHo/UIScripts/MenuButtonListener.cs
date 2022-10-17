using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonListener : MonoBehaviour
{
    GameObject modeChangeButton, SettingButton;
    Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        modeChangeButton = GameObject.Find("MenuButtons").transform.Find("ModeChangeButton").gameObject;
        SettingButton = GameObject.Find("MenuButtons").transform.Find("SettingButton").gameObject;

        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(
            delegate {
                clickMenuButton();
            });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickMenuButton()
    {
        if (toggle.isOn)
        {
            modeChangeButton.SetActive(true);
            SettingButton.SetActive(true);
        }
        else // 애니메이션을 꺼야함, 오브젝트도 꺼야함
        {
            modeChangeButton.GetComponent<Animator>().SetTrigger("close");
            SettingButton.GetComponent<Animator>().SetTrigger("close");
        }

    }
}
