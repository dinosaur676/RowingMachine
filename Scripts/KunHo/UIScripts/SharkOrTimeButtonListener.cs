using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkOrTimeButtonListener : MonoBehaviour
{
    [SerializeField]
    private NameUtil.SceneName nextSceneName;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneController.Instance.NextScene(NameUtil.getSceneName(nextSceneName));
        });
    }
}
