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

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }



    void Update()
    {
        if (EnemyController.instance.Distance >= 2 || 
             MesureManager.Instance.Distance >= 2 )
        {
            endGame();
        }

    }

    private void endGame()
    {
        LoadingSceneController.LoadScene("ModeSelection");
        
    }
    
    
}
