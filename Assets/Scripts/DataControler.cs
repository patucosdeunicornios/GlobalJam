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
        /* Debug.Log(value);
        using (StreamWriter streamWriter = File.CreateText(value))
        {
            streamWriter.Write(value);
        }*/
        score.addData(new PlayerData(nombre, value));
        //PlayerData PlayerData = new PlayerData(nombre, value);

        string json = JsonUtility.ToJson(score);
        Debug.Log(json);
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
            //score = new Score(JsonUtility.FromJson<Score>(dataPath));
            Debug.Log(dataPath);


            //JsonUtility.FromJsonOverwrite(dataPath, score);
            

            //foreach(PlayerData data in playerData)
            //{
            //    score.addData(data);
            //    Debug.Log("Scores: " + score);
            //}
        }
    }
}
