using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    static private SceneController instance = null;

    private Stack<string> sceneStack;

    static public SceneController Instance
    {
        get
        {
            if (instance == null)
                instance = instance = GameObject.FindGameObjectWithTag("UtilManager").GetComponent<SceneController>();

            return instance;

        }
    }

    void Start()
    {
        sceneStack = new Stack<string>();
    }

    public void NextScene(string nextScene, bool isWait = false)
    {
        LoadingSceneController.LoadScene(nextScene, isWait);
    }

    public void endWaitLoadingScene()
    {
        LoadingSceneController.endWait();
    }

    public bool isRootScene()
    {
        return SceneManager.GetActiveScene().name.Equals(NameUtil.SCENE_MODESELECTION);
    }

}
