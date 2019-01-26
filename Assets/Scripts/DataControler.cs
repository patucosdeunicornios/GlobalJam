using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataControler : MonoBehaviour
{

    string dataPath;
    Score score = new Score();
    GameObject CanvasGameObject;

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

    public void showData()
    {

       

        readData();
        GameObject CanvasGameObject2 = GameObject.Find("MenuCanvas");
        CanvasGameObject2.GetComponent<Canvas>().enabled = false;

        GameObject CanvasGameObject = GameObject.Find("ScoreCanvas");
        CanvasGameObject.GetComponent<Canvas>().enabled = true;

        GameObject[] gameTextObject = GameObject.FindGameObjectsWithTag("Score");

        for (int i = 0; i < score.scores.Count; i++)
        {
            gameTextObject[i].GetComponent<Text>().text = score.scores[i].name + ":     " + score.scores[i].value;
        }
    }


}
