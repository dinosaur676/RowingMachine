using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임 정보 관리하는 게임 매니저
public class TimeAttackManager : MonoBehaviour
{
    // 싱글톤 접근용 프로퍼티
    public static TimeAttackManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if(m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아서 할당
                m_instance = FindObjectOfType<TimeAttackManager>();
            }
            // 싱글톤 오브젝트 반환
            return m_instance;
        }
    }
    private static TimeAttackManager m_instance; // 싱글톤이 할당될 static 변수


    private Text distanceAndTimeText;
    private float time;
    private float distance;  // 거리 km단위
    public bool gamestate{ get; private set; }

    private TimeUtil.Timer timer;

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
        time = 60.0f;
        distance = 0.0f;
        gamestate = true;
        timer = new TimeUtil.Timer(time);

        // Update is called once per frame
    }


    void Update()
    {
       
    }

    private void endGame()
    {
        StartCoroutine(endGameNextScene());
    }


    IEnumerator endGameNextScene()
    {
        timer = new TimeUtil.Timer(5.0f);


        while(!timer.isEnd)
        {
            yield return null;
        }

        LoadingSceneController.LoadScene("Training");
    }
}
