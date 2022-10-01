using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class popupSystem : MonoBehaviour
{
   
    public delegate void YesnoCallBack();
    private event YesnoCallBack yesCallBack;
    private event YesnoCallBack noCallBack;
    private event YesnoCallBack _1kmCallBack;
    private event YesnoCallBack _2kmCallBack;
    private event YesnoCallBack _5kmCallBack;
    private event YesnoCallBack _toggleOffCallBack;
    private event YesnoCallBack _toggleOnCallBack;
    private Animator anim;


    private void Awake()
    {
        anim= transform.GetComponent<Animator>();
    }

    public void SetYesCallback(YesnoCallBack listener)
    {
        yesCallBack += listener;
    }

    public void SetNoCallback(YesnoCallBack listener)
    {
        noCallBack += listener;
    }
    public void Set1kmCallback(YesnoCallBack listener)
    {
        _1kmCallBack += listener;
    }
    public void Set2kmCallback(YesnoCallBack listener)
    {
        _2kmCallBack += listener;
    }
    public void Set5kmCallback(YesnoCallBack listener)
    {
        _5kmCallBack += listener;
    }
    public void SetToggleOff(YesnoCallBack listener)
    {
        _toggleOffCallBack += listener;
    }
    public void SetToggleOn(YesnoCallBack listener)
    {
        _toggleOnCallBack += listener;
    }

    public void OnYes()
    {
        yesCallBack?.Invoke();
    }

    public void OnNo()
    {
        noCallBack?.Invoke();
    }
    public void On1km()
    {
        _1kmCallBack?.Invoke();
    }
    public void On2km()
    {
        _2kmCallBack?.Invoke();
    }
    public void On5km()
    {
        _5kmCallBack?.Invoke();
    }
    public void OnToggle()
    {
        _toggleOnCallBack?.Invoke();
    }
    public void OffToggle()
    {
        _toggleOffCallBack?.Invoke();
    }


    private void Update()
    {
        //Debug.Log("팝업창 시간: " + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("close"))
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) // 애니메이션이 끝났으면
            {
                
                transform.gameObject.SetActive(false);
            }
        }
    }
}
