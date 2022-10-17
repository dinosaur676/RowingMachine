using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Text distanceAndTimeText;
    private float distance;  // 거리 km단위


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
        distanceAndTimeText = GameObject.Find("Distance&Time").transform.Find("Text").GetComponent<Text>();
        stopWatch = new TimeUtil.StopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        distance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600;

        if (((int)stopWatch.Time / 5) % 2 == 0)
        {
            distanceAndTimeText.text = "거리 : " + (distance).ToString("F3") + "km";
        }
        else
        {
            distanceAndTimeText.text = "시간 : " + (int)stopWatch.Time / 60 + "분 " + (int)stopWatch.Time % 60 + "초";
        }
    }

    public void UpdateUI(float surviveTime, float speed)
    {
        UI.UpdateInfoUI(surviveTime, speed);
    }

    public void EndGame()
    {
        player.GetComponentInChildren<CharacterManager>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
    }

}
