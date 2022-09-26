using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController_CircleMap : MonoBehaviour
{
    [SerializeField] GameObject Success, Over, RestartButton, QuitButton;
    [SerializeField] Text countdownText;
    [SerializeField] float setTime = 10f;



    void Start()
    {
        countdownText.text = setTime.ToString();
    }

    void Update()
    {
        {
            if (setTime > 0)
                setTime -= Time.deltaTime;
            else if (setTime <= 0)
                Time.timeScale = 0.0f;
            countdownText.text = "Remain Time : " + Mathf.Round(setTime).ToString();

            EndTime();

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameQuit();
        }
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    void EndTime()
    {
        if (setTime <= 0)
        {
            Time.timeScale = 0;
            Success.SetActive(true);
            RestartButton.SetActive(true);
            QuitButton.SetActive(true);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Circle_Map");
        Time.timeScale = 1;
        Success.SetActive(false);
        Over.SetActive(false);
        QuitButton.SetActive(false);
        RestartButton.SetActive(false); ;
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Shark")
        {
            Debug.Log("Ãæµ¹ÇÔ");
            Time.timeScale = 0;
            Over.SetActive(true);
            RestartButton.SetActive(true);
            QuitButton.SetActive(true);

        }
    }
}
