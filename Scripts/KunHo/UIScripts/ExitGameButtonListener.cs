using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameButtonListener : MonoBehaviour
{
    GameObject ExitUI;

    // Start is called before the first frame update
    void Start()
    {
        ExitUI = GameObject.Find("UI").transform.Find("ExitUI").gameObject;
        GetComponent<Button>().onClick.AddListener(OpenExitUI);
    }

    public void OpenExitUI()
    {
        if(SceneController.Instance.isRootScene())
        {
            ExitUI.SetActive(true);
        }
        else
        {
            SceneController.Instance.NextScene(NameUtil.SCENE_TRAINING);
        }

        


    }
}
