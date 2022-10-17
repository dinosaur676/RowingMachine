using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeChangeButtonListenr : MonoBehaviour
{
    GameObject ModeChangeUI;
    void Start()
    {
        ModeChangeUI = GameObject.Find("UI").transform.Find("ModeChangeUI").gameObject;
        GetComponent<Button>().onClick.AddListener(OpenModeUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenModeUI()
    {
        /*
        GameObject obj = Resources.Load<GameObject>("Prefabs/ExitUI");
        GameObject parent = GameObject.Find("UI");
        GameObject settingUI = Instantiate<GameObject>(obj, parent.transform, false);
        */

        ModeChangeUI.SetActive(true);

        popupSystem popupScript = ModeChangeUI.GetComponent<popupSystem>();

        popupScript.SetYesCallback(() =>
        {
            ModeChangeUI.GetComponent<Animator>().SetTrigger("close");
            //ExitUI.SetActive(false);
        });
        popupScript.SetNoCallback(() =>
        {
            ModeChangeUI.GetComponent<Animator>().SetTrigger("close");
            //ExitUI.SetActive(false);
        });

    }
}
