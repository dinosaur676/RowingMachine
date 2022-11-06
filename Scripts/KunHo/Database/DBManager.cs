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

    public List<RowingDTO> getDistance()
    {
        List<RowingDTO> output = new List<RowingDTO>();
        string sql = "Select * from Rowing";
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = sql;
        IDataReader dataReader = dbCommand.ExecuteReader();

        while (dataReader.Read())
        {
            RowingDTO dto = new RowingDTO();
            dto.Date = System.DateTime.ParseExact(dataReader.GetString(0), "yyyy/MM/dd - HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            dto.Time = dataReader.GetInt32(1);
            dto.Distance = dataReader.GetInt32(2);
            dto.IsSuccess = true;

            output.Add(dto);
        }


        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;

        return output;
    }

    public void insertDistance(int time, int distance)
    {

        RowingDTO dto = new RowingDTO();
        dto.Time = time;
        dto.Distance = distance;

        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();

        dbCommand.CommandText = "insert into Rowing values(" + dto.ToString() + ")";
        dbCommand.ExecuteNonQuery();

        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;

    }

    public void insertCalorie()
    {
        CalorieDTO dto = new CalorieDTO();
        dto.Time = (int)TimeManager.Instance.Total_time;
        dto.Calorie = (int)(dto.Time * 0.28f);

        string sql = "";
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();

        if(isCalorieExist(dto))
        {
            string date = dto.getDay() + "%";
            sql = "Update Calorie set calorie = calorie + " + dto.Calorie + ", time = time + " + dto.Time;
            sql += " Where Date like " + "\"" + date + "\"";
        }
        else
        {
            sql = "insert into Calorie values(" + dto.ToString() + ")";
        }

        dbCommand.CommandText = sql;
        dbCommand.ExecuteNonQuery();

        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;

    }

    private bool isCalorieExist(CalorieDTO dto)
    {
        string date = dto.getDay() + "%";
        string sql = "Select * from Calorie where Date like " + "\"" + date + "\"";
        bool output = false;

        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = sql;
        IDataReader dataReader = dbCommand.ExecuteReader();

        while (dataReader.Read())
        {
            output = true;
            break;
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
