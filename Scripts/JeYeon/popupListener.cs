using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popupListener : MonoBehaviour
{
    public GameObject popupPrefab;
    private GameObject popup;
    void Start()
    {

        GetComponent<Button>().onClick.AddListener(() => {
            if (popup == null)
            {
                popup = Instantiate(popupPrefab);
                popup.transform.SetParent(GameObject.Find("UI").transform, false);
            }
        });

    }
    void Update()
    {
        
    }
}
