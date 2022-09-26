using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Move", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행

        if (!SpeedManager.Instance.isStop)
            playerAnimator.SetFloat("Move", 1.0f);
        else
            playerAnimator.SetFloat("Move", 0.0f);
    }

}
