using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButtonListener : MonoBehaviour
{
    GameObject SettingUI;
    void Start()
    {
        SettingUI = GameObject.Find("UI").transform.Find("SettingUI").gameObject;
        GetComponent<Button>().onClick.AddListener(OpenSettingUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSettingUI()
    {
        SettingUI.SetActive(true);
        /*
        popupSystem popupScript = SettingUI.GetComponent<popupSystem>();

        popupScript.SetYesCallback(() =>
        {
            SettingUI.GetComponent<Animator>().SetTrigger("close");

        });
        popupScript.SetNoCallback(() =>
        {
            SettingUI.GetComponent<Animator>().SetTrigger("close");

        });
        */
    }
}
