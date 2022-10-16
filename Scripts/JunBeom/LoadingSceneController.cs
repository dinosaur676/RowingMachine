using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{

    [SerializeField]
    Image progressBar;

    static string nextScene;
    static bool _isWait;

    public static void LoadScene(string sceneName, bool isWait = false)
    {
        nextScene = sceneName;
        _isWait = isWait;
        SceneManager.LoadScene("LoadingScene");
    }

    public static void endWait()
    {
        _isWait = false;
    }

    void Start()
    {
        progressBar.fillAmount = 0.0f;
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;

        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.8f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else if(!_isWait)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
            else
            {
                timer = 0.0f;
            }
        }

    }
}
