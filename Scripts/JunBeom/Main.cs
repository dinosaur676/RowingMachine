using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void OnclickStart()
    {
        LoadingSceneController.LoadScene("Beginning Scene");
    }
    public void OnclickExit()
    {
        Application.Quit();
    }
}
