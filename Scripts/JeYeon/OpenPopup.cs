using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPopup : MonoBehaviour
{
    public enum CloseType
    {
        windowClose,
        ApplicationClose
    };

    private Vector3 originScale;
    private float time = 0.3f;

    public GameObject yesbutton;
    public GameObject nobutton;

    [SerializeField]
    CloseType type;

    private void Start()
    {
        startPopup();
    }
    private void Awake()
    {
        
        if (yesbutton != null)
        {
            yesbutton.GetComponent<Button>().onClick.AddListener(closePopup);
            if(type == CloseType.ApplicationClose)
                yesbutton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    DBManager.Instance.insertCalorie();
                    Application.Quit();
                });
        }
        if (nobutton != null)
            nobutton.GetComponent<Button>().onClick.AddListener(closePopup);

        originScale = transform.localScale; //���� ũ�� ����
    }
    public void startPopup()
    {
        StartCoroutine(startPopupAnim());
    }
    IEnumerator startPopupAnim()
    {
        float currentTime = 0;
        
        while (currentTime <= time)
        {            
            transform.localScale = originScale * (currentTime/ time);
            currentTime += Time.deltaTime;

            yield return null;   
        }    
    }
    public void closePopup()
    {
        StartCoroutine(closePopupAnim());    
    }

    IEnumerator closePopupAnim()
    {
        float currentTime = 0;

        while (currentTime <= time)
        {

            transform.localScale = originScale * (1 - currentTime/ time);
            currentTime += Time.deltaTime;
            
            yield return null;
        }

        Destroy(gameObject);
    }
}
