using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    /*
    public void SetDisable(string animName)
    {
        StartCoroutine(disable(animName));
    }

    IEnumerator disable(string animName)
    {
        anim.SetTrigger("close");
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        while (anim.GetCurrentAnimatorStateInfo(0).IsName(animName) &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            Debug.Log("와일문");   
            yield return null;
        }
        transform.gameObject.SetActive(false);
    }
    
    */
    
    
    private void Update()
    {

        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("slidClose") || anim.GetCurrentAnimatorStateInfo(0).IsName("setslidClose"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) // 애니메이션이 끝났으면
            {
                transform.gameObject.SetActive(false);
            }
        }
        
    }
    
}
