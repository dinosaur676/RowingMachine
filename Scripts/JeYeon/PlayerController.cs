using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5.0f;
    public float _rotateSpeed = 100f;
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }
 

    
    private void FixedUpdate()
    {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행

        Move();
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    // 캐릭터 움직임
    private void Move()
    {
        Vector3 moveDistance = playerInput.move * transform.forward * _speed * Time.deltaTime;
        // 리지드바디를 이용해 게임 오브젝트 위치변경
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }
    
}
    

