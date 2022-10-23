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
    
        ModeChangeUI.SetActive(true);

    }
}
