using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCamera : MonoBehaviour
{
    GameObject player;
    GameObject playerCamera;
    float distance = 5.0f;
    float radian;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = new GameObject("playerCamera");
        playerCamera.transform.SetParent(transform.root.parent);
        
        Camera camera = playerCamera.AddComponent<Camera>();
        camera.cullingMask = 1 << LayerMask.NameToLayer("Player");
        camera.targetTexture = (RenderTexture)GetComponent<RawImage>().texture;
       
        radian = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        radian += Mathf.PI / 2 * Time.deltaTime;
        playerCamera.transform.position = getPosition(radian);
        playerCamera.transform.LookAt(player.transform);
    }

    private Vector3 getPosition(float theta)
    {
        float x = Mathf.Sin(theta);
        float y = 3.0f;
        float z = Mathf.Cos(theta);

        Vector3 newPos = new Vector3(x, 0.0f, z).normalized * distance;

        Vector3 output = player.transform.position - newPos;
        output.y = y;
        
        
        return output;
    }

    private void OnDestroy()
    {
        Destroy(playerCamera);
    }
}
