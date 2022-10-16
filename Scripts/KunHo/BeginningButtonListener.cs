using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginningButtonListener : MonoBehaviour
{
    public GameObject Optionpanel;
    public void OnClickStart_btn()
    {
        LoadingSceneController.LoadScene("Survive");
    }
    public void OnClickSetting()
    {
        Optionpanel.SetActive(true);
    }
    public void OnClickSettingExit()
    {
        Optionpanel.SetActive(false);

    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

}
