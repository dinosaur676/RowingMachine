using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public GameObject menuset;

    public void OnClickMenu()
    {
        Time.timeScale = 0;
        menuset.SetActive(true);
    }
    public void OnClickPlay()
    {
        Time.timeScale = 1;
        menuset.SetActive(false);
    }
    public void OnClickRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnClickQuit()
    {
        LoadingSceneController.LoadScene("Beginning Scene");
    }
}
