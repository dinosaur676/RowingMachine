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
    static private DBManager instance = null;

    static public DBManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("UtilManager").GetComponent<DBManager>();

            return instance;
        }
    }


    private string conn, sqlQuery;
    IDbConnection dbConn;
    IDbCommand dbCmd;
    private IDataReader reader;
    string DBName = "Rowing.db";


    private void Awake()
    {
        StartCoroutine(DBCreate());
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DBCreate()
    {
        string filepath = string.Empty;
        if(Application.platform == RuntimePlatform.Android)
        {
            filepath = Application.persistentDataPath + "/" + DBName;
            if (!File.Exists(filepath))
            {
                UnityWebRequest unityWebRequest = UnityWebRequest.Get("jar:file://" + Application.dataPath 
                    + "!/assets/" + DBName);

                unityWebRequest.downloadedBytes.ToString();
                yield return unityWebRequest.SendWebRequest().isDone;

                File.WriteAllBytes(filepath, unityWebRequest.downloadHandler.data);
            }
            Debug.Log(filepath);
        }
        else //±âÅ¸ ÇÃ·§Æû (pcÀÏ °æ¿ì)
        {
            filepath = Application.dataPath + "/" + DBName;
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + "/" + DBName, filepath);
            }
        }

        DBConnectionCheck();
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

            }
            else
            {

            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }

    public List<CalorieDTO> getCalories()
    {
        List<CalorieDTO> output = new List<CalorieDTO>();
        string sql = "Select * from Calorie";
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = sql;
        IDataReader dataReader = dbCommand.ExecuteReader();

        while(dataReader.Read())
        {
            CalorieDTO dto = new CalorieDTO();
            dto.Date = System.DateTime.ParseExact(dataReader.GetString(0), "yyyy/MM/dd - HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            dto.Calorie = dataReader.GetInt32(1);
            dto.Time = dataReader.GetInt32(2);

            output.Add(dto);
        }


        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;

        return output;
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
