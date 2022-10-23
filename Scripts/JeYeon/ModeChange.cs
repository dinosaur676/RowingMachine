using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadModeSelectionScene()
    {
        LoadingSceneController.LoadScene("ModeSelection");
    }
}
