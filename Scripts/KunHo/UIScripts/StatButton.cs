using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatButton : MonoBehaviour
{
    GameObject statObject;
    // Start is called before the first frame update
    void Start()
    {
        statObject = GameObject.Find("StatUI");
        GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(statObject);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
