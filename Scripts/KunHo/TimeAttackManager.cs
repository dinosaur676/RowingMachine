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

    // 게임정보 표시 UI
    public Text timeText, distanceText, speedText, endTime;
    public GameObject _info_ui, _kmSet, _end;
    public InputField KMField, TimeField;

    
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
        distance = 0.0f;
        gamestate = true;
        changeUI(km: true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onClickButton()
    {
        timer = new TimeUtil.Timer(float.Parse(TimeField.text));
        changeUI(info: true);
        StartCoroutine(update());
    }

    private void endGame()
    {
        changeUI(end : true);
        StartCoroutine(endGameNextScene());
    }

    private void changeUI(bool km = false, bool info = false, bool end = false)
    {
        _kmSet.SetActive(km);
        _info_ui.SetActive(info);
        _end.SetActive(end);
    }

    IEnumerator endGameNextScene()
    {
        timer = new TimeUtil.Timer(5.0f);

        while(!timer.isEnd)
        {
            endTime.text = "남은시간 : " + (int)timer.Time + "초";
            yield return null;
        }

        LoadingSceneController.LoadScene("Training");
    }
    IEnumerator update()
    {
        while(!_end.activeSelf)
        {
            // 거리 계산
            distance += (float)SpeedManager.Instance.BoatSpeed * Time.deltaTime / 3600 ;
            distanceText.text = "거리 : " + (distance).ToString("F3") + "km";

            //속도 표시
            speedText.text = "속도: " + SpeedManager.Instance.BoatSpeed.ToString("F2") + "km/h";


            // 시간을 UI에 표시
            timeText.text = "시간 : " + (int)timer.Time / 60 + "분 " + (int)timer.Time % 60 + "초";

            if (timer.isEnd || distance >= float.Parse(KMField.text))
            {
                endGame();
            }

            yield return null;
        }
    }
}
