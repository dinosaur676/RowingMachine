using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.Networking;

public class DBManager : MonoBehaviour
{
    public Text debugText;

    private string conn, sqlQuery;
    IDbConnection dbConn;
    IDbCommand dbCmd;
    private IDataReader reader;
    string DBName = "Test.db";

    bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DBCreate());
    }

    // Update is called once per frame
    void Update()
    {
        if (!test)
        {
            DBConnectionCheck();
            DBQuery("create table test (" +
                "id int notnull" +
                ");");

            test = true;
        }
    }
    IEnumerator DBCreate()
    {
        string filepath = string.Empty;
        if(Application.platform == RuntimePlatform.Android)
        {
            filepath = Application.persistentDataPath + "/" + DBName;
            debugText.text += filepath + '\n';
            if (!File.Exists(filepath))
            {
                debugText.text += "파일생성 들어옴" + '\n';
                UnityWebRequest unityWebRequest = UnityWebRequest.Get("jar:file://" + Application.dataPath 
                    + "!/assets/" + DBName);

                unityWebRequest.downloadedBytes.ToString();
                yield return unityWebRequest.SendWebRequest().isDone;

                File.WriteAllBytes(filepath, unityWebRequest.downloadHandler.data);
                debugText.text += "성공?" + '\n';
            }
        }
        else //기타 플랫폼 (pc일 경우)
        {
            filepath = Application.dataPath + "/" + DBName;
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + "/" + DBName, filepath);
            }
        }
    }

    public string GetDBFilePath()
    {
        string str = string.Empty;
        if (Application.platform == RuntimePlatform.Android)
        {
            str = "URI=file:" + Application.persistentDataPath + "/" + DBName;

        }
        else
        {
            str = "URI=file:" + Application.dataPath + "/" + DBName;
        }
        return str;
    }

    public void DBConnectionCheck()
    {
        try
        {
            IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
            dbConnection.Open();

            if (dbConnection.State == ConnectionState.Open)
            {
                debugText.text += "연결 성공" + '\n';
            }
            else
            {
                debugText.text += "연결 실패" + '\n';
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }
    private void DBQuery(string query)
    {
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();

        dbCommand.CommandText = query;
        dbCommand.ExecuteNonQuery();

        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }

    
}
