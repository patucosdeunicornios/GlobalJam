using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DataControler
{

    string dataPath;
    Score score = new Score();

    public void saveData(string nombre, float value)
    {

        dataPath = Path.Combine(Application.persistentDataPath, "HighScore.json");
        score.addData(new PlayerData(nombre, value));
        string json = JsonUtility.ToJson(score);
        using (StreamWriter streamWriter = File.CreateText(dataPath))
        {
            streamWriter.Write(json);
        }
    }

    public void readData()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "HighScore.json");

        if (File.Exists(dataPath))
        {
            string dataAsJson = File.ReadAllText(dataPath);

            score = JsonUtility.FromJson<Score>(dataAsJson);
            foreach(PlayerData data in score.scores)
            {
               Debug.Log("Scores: " + data.name+" points:"+data.value);
            }
        }
    }
}
