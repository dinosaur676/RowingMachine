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


	void Start()
    {
		deviceName = "kunBT";

		bluetoothHelper = BluetoothHelper.GetInstance(deviceName);
		bluetoothHelper.setTerminatorBasedStream("\n");

		DontDestroyOnLoad(transform.gameObject);

		StartCoroutine(Connect());
	}


	void Update()
    {
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
		LoadingSceneController.LoadScene("Beginning Scene", true);


		while (!bluetoothHelper.isConnected())
        {
			tryConnect();
			yield return new WaitForSeconds(3.0f);
		}

		bluetoothHelper.StartListening();
		Debug.Log("Connected");
		LoadingSceneController.endWait();
		yield return null;
	}


}
