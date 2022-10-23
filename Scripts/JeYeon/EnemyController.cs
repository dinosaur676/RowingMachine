using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    private float enemy_distance;
    private float enemy_speed = 5.0f;
    public static EnemyController instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아서 할당
                m_instance = FindObjectOfType<EnemyController>();
            }
            // 싱글톤 오브젝트 반환
            return m_instance;
        }
    }
    private static EnemyController m_instance; // 싱글톤이 할당될 static 변수

    float distance;
    public float Distance
    {
        get
        {
            return distance;
        }
    }


    void Update()
    {
        distance += (float)enemy_speed * Time.deltaTime / 3600; 
    }
}
