using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string playerName;
    public string highScore;
    public int highScorePoints;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance= this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    [System.Serializable]
    class SaveData
    {
        
        public string highScore;
        public int highScorePoints;

    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScorePoints = highScorePoints;

        string json= JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data= JsonUtility.FromJson<SaveData>(json);
            highScore= data.highScore;
            highScorePoints= data.highScorePoints;
        }
    }
}
