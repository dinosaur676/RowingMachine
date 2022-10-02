using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임 정보 관리하는 게임 매니저
public class TrainGameManager_JeYeon : MonoBehaviour
{
    // 싱글톤 접근용 프로퍼티
    public static TrainGameManager_JeYeon instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if(m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아서 할당
                m_instance = FindObjectOfType<TrainGameManager_JeYeon>();
            }
            // 싱글톤 오브젝트 반환
            return m_instance;
        }
    }

    private static TrainGameManager_JeYeon m_instance; // 싱글톤이 할당될 static 변수


    GameObject player;
    public Text timeText;

    private float playTime;
    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    } 

    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        PlayerState(false);
        TrainUIManager_JeYeon.instance.LoadKmSetUI();
     
    }

    // Update is called once per frame
    void Update()
    {
       
        // UI 갱신
        if (Input.GetKey(KeyCode.W))
        {
            TrainUIManager_JeYeon.instance.UpdateSpeedText();
        }

        /*
        if (TrainUIManager.instance.distance != 0)
        {
            playTime += Time.deltaTime;
        }
        else
        {
            playTime = 0;
        }

        timeText.text = "시간 : " + (int)playTime / 60 + "분 " + (int)playTime % 60 + "초";


        if (TrainUIManager.instance.goalDistance != 0 && TrainUIManager.instance.distance >= TrainUIManager.instance.goalDistance)
        {
            EndGame();
        }
        */

    }

    public void PlayerState(bool state)
    {
        player.GetComponent<PlayerController>().enabled = state;
        player.GetComponent<PlayerInput>().enabled = state;
        player.GetComponent<AudioSource>().enabled = state;
        player.GetComponent<Animator>().enabled = state;
        player.GetComponent<Rigidbody>().useGravity = state;
        
    }

    public void EndGame()
    {
        //TrainUIManager.instance.LoadEndUI();

        PlayerState(false);
    }
}
