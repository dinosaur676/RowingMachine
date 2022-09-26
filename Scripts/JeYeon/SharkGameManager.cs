using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkGameManager : MonoBehaviour
{
    private static SharkGameManager m_instance;
    // 싱글톤 접근용 프로퍼티
    public static SharkGameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<SharkGameManager>();
            }

            return m_instance;
        }
    }


    // 게임에 필요한 변수
    private GameObject player;
    private TimeUtil.StopWatch stopWatch;
    private SharkUI UI;


    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 SharkGameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        //stopWatch = new TimeUtil.StopWatch();
        UI = FindObjectOfType<SharkUI>();
        UI.startGameUI();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateUI(stopWatch.Time, (float)SpeedManager.Instance.BoatSpeed);
    }

    public void UpdateUI(float surviveTime, float speed)
    {
        UI.UpdateInfoUI(surviveTime, speed);
    }

    public void EndGame()
    {
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerInput>().enabled = false;
        player.GetComponentInChildren<CharacterManager>().enabled = false;
        player.GetComponent<Animator>().enabled = false;

        UI.endGameUI();
    }
}
