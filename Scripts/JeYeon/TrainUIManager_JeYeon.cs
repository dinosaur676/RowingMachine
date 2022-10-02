using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;

public class TrainUIManager_JeYeon : MonoBehaviour
{
    public static TrainUIManager_JeYeon instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아서 할당
                m_instance = FindObjectOfType<TrainUIManager_JeYeon>();
            }
            // 싱글톤 오브젝트 반환
            return m_instance;
        }
    }

    private static TrainUIManager_JeYeon m_instance; // 싱글톤이 할당될 static 변수


    public GameObject player;
    public GameObject ExitUI;
    public GameObject SettingUI;
    public GameObject ModeUI;
    public GameObject KmSetUI;
    public Toggle toggle;
    public GameObject modeButton;
    public GameObject SetButton;
    public GameObject menuButton;

    private float _speed;
    public Text speedText;

    private void Awake()
    {
       
    }

    public void OpenSettingUI()
    {
        

        SettingUI.SetActive(true);

        popupSystem popupScript = SettingUI.GetComponent<popupSystem>();

        popupScript.SetYesCallback(() =>
        {
            SettingUI.GetComponent<Animator>().SetTrigger("close");
            
        });
        popupScript.SetNoCallback(() =>
        {
            SettingUI.GetComponent<Animator>().SetTrigger("close");
            
        });
    
    }
    public void OpenExitUI()
    {
        

        ExitUI.SetActive(true);

        popupSystem popupScript = ExitUI.GetComponent<popupSystem>();

        popupScript.SetYesCallback(() =>
        {
            ExitUI.GetComponent<Animator>().SetTrigger("close");
            //ExitUI.SetActive(false);
        });
        popupScript.SetNoCallback(() =>
        {
            ExitUI.GetComponent<Animator>().SetTrigger("close");
            //ExitUI.SetActive(false);
        });

    }

    public void OpenModeUI()
    {
        /*
        GameObject obj = Resources.Load<GameObject>("Prefabs/ExitUI");
        GameObject parent = GameObject.Find("UI");
        GameObject settingUI = Instantiate<GameObject>(obj, parent.transform, false);
        */

        ModeUI.SetActive(true);

        popupSystem popupScript = ModeUI.GetComponent<popupSystem>();

        popupScript.SetYesCallback(() =>
        {
            ModeUI.GetComponent<Animator>().SetTrigger("close");
            //ExitUI.SetActive(false);
        });
        popupScript.SetNoCallback(() =>
        {
            ModeUI.GetComponent<Animator>().SetTrigger("close");
            //ExitUI.SetActive(false);
        });

    }
    public void clickMenuButton()
    {
        
        if (toggle.isOn)
        {
            modeButton.SetActive(true);
            SetButton.SetActive(true);

        }
        else // 애니메이션을 꺼야함, 오브젝트도 꺼야함
        {
            modeButton.GetComponent<Animator>().SetTrigger("close");
            SetButton.GetComponent<Animator>().SetTrigger("close");
            /*
            modeButton.GetComponent<ButtonAnim>().SetDisable("slidClose");
            SetButton.GetComponent<ButtonAnim>().SetDisable("setslidClose");
            */
        }

    }


    public void UpdateSpeedText()
    {
        speedText.text = speedText.text = "속도 : " + player.GetComponent<PlayerController>()._speed * 3.6f + " km/h";
    }
    public void LoadKmSetUI()
    {

        KmSetUI.SetActive(true);

        popupSystem popupScript = KmSetUI.GetComponent<popupSystem>();

        popupScript.Set1kmCallback(() =>
        {
            KmSetUI.GetComponent<Animator>().SetTrigger("close");
            
        });
        popupScript.Set2kmCallback(() =>
        {
            KmSetUI.GetComponent<Animator>().SetTrigger("close");
            
        });
        popupScript.Set5kmCallback(() =>
        {
            KmSetUI.GetComponent<Animator>().SetTrigger("close");

        });


        TrainGameManager_JeYeon.instance.PlayerState(true);
        
    }


    /*
    
    
    public Text distanceText;
    
    public float distance { get; private set; }
    public float goalDistance { get; private set; }
    
    private float playTime;

    
    
    public GameObject InfoUI;
    
    
    public void LoadInfoUI(int goal)
    {
        KmSetUI.SetActive(false);
        InfoUI.SetActive(true);


        goalDistance = 0.02f;

        TrainGameManager.instance.PlayerState(true);

    }

    public void LoadEndUI()
    {
        InfoUI.SetActive(false);
        EndUI.SetActive(true);
    }

    public void UpdateInfoUI()
    {

        
        speedText.text = speedText.text = "속도: " + player.GetComponent<PlayerController>()._speed * 3.6f;

        distance += (int)player.GetComponent<PlayerController>()._speed * Time.deltaTime / 3600;
        distanceText.text = distanceText.text = "거리 : " + (distance).ToString("F3") + "km";


    }
    */
}
