using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject modeChangeButton;
    public GameObject SettingButton;
    public GameObject ExitButton;


    public void clickMenuButton()
    {
        if (transform.GetComponent<Toggle>().isOn)
        {
            modeChangeButton.GetComponent<ButtonSlide>().startSlide(1);
            SettingButton.GetComponent<ButtonSlide>().startSlide(2);
            ExitButton.GetComponent<ButtonSlide>().startSlide(3);
        }
        else 
        {
            
            modeChangeButton.GetComponent<ButtonSlide>().closeSlide();
            SettingButton.GetComponent<ButtonSlide>().closeSlide();
            ExitButton.GetComponent<ButtonSlide>().closeSlide();
            
        }

    }
}
