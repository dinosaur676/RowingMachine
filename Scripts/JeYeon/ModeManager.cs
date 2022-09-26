using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeManager: MonoBehaviour
{
    

    // Start is called before the first frame update
        

    public void loadTraining()
    {
        SceneManager.LoadScene("Training");
        // 안녕하세요
        
    }
    public void loadComp()
    {
        SceneManager.LoadScene("Survive");
    }
    
}
