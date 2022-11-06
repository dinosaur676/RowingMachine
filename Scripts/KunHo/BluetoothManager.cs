using System;
using System.Collections;
using System.Collections.Generic;
using ArduinoBluetoothAPI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BluetoothManager : MonoBehaviour
{
    BluetoothHelper bluetoothHelper;
    string recv_msg;
    string deviceName;

    public bool TEST_MODE = false;
    [Range(0.0f, 7.0f)]
    public float TEST_SPEED;


    void Start()
    {
        if (!TEST_MODE)
        {
            deviceName = "kunBT";

            bluetoothHelper = BluetoothHelper.GetInstance(deviceName);
            bluetoothHelper.setTerminatorBasedStream("\n");

            StartCoroutine(Connect());
        }
        else
        {
            StartCoroutine(TEST_NEXTSCENE());
            StartCoroutine(TEST_SPEEDMANAGER());
        }

        DontDestroyOnLoad(transform.gameObject);
    }


    void Update()
    {
        if (TEST_MODE)
            return;

        if (bluetoothHelper.isConnected())
        {
            recv_msg = bluetoothHelper.Read();

            if (!recv_msg.Equals(""))
            {
                SpeedManager.Instance.GoalBoatSpeed = Double.Parse(recv_msg);
            }
        }
    }
    void tryConnect()
    {
        try
        {
            if (bluetoothHelper.isDevicePaired())
            {
                bluetoothHelper.Connect();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    IEnumerator Connect()
    {
		LoadingSceneController.LoadScene(NameUtil.SCENE_MODESELECTION, true);


        while (!bluetoothHelper.isConnected())
        {
            tryConnect();
            Debug.Log("����");
            yield return new WaitForSeconds(3.0f);
        }

        bluetoothHelper.StartListening();
        Debug.Log("Connected");
        LoadingSceneController.endWait();
        yield return null;
    }

    IEnumerator TEST_NEXTSCENE()
    {
		LoadingSceneController.LoadScene(NameUtil.SCENE_MODESELECTION, true);

        for (int i = 0; i < 1; ++i)
        {
            yield return new WaitForSeconds(3.0f);
        }

        LoadingSceneController.endWait();
        yield return null;
    }
    IEnumerator TEST_SPEEDMANAGER()
    {

        while (true)
        {
            if(TEST_SPEED > 0.1f)
                SpeedManager.Instance.GoalBoatSpeed = TEST_SPEED;

            yield return new WaitForSeconds(0.5f);
        }
    }

}
