using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    
    public Image progressImage;
    public Image PlayerIcon;
    public Image GoalIcon;
    public Text percentText;

    

    //프로그래스 값
    float pbValue;
    void Start()
    {
        GoalIcon.rectTransform.localPosition = new Vector3(progressImage.rectTransform.sizeDelta.x/2,
            GoalIcon.rectTransform.localPosition.y, GoalIcon.rectTransform.localPosition.z);
    }
    void Update()
    {
        
        pbValue = MesureManager.Instance.Distance;
        
        float x = progressImage.rectTransform.sizeDelta.x * progressImage.rectTransform.localScale.x;

        progressImage.fillAmount = pbValue / 2;


        float positionX = x * progressImage.fillAmount - (x/2);
        
        

        PlayerIcon.rectTransform.localPosition = new Vector3(positionX, PlayerIcon.rectTransform.localPosition.y,
            PlayerIcon.rectTransform.localPosition.z);

        percentText.text = Math.Round(progressImage.fillAmount * 100, 1) + " %";




    }
}
