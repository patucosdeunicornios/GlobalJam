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
    int totalScores;
    private IComparer<PlayerData> value;
    bool writeable;

    public void saveData(string nombre, float value)
    {
        writeable = false;
        checkData(value);
        if (writeable)
        {
            Debug.Log("Es writeable");
            dataPath = Path.Combine(Application.persistentDataPath, "HighScore.json");
            score.addData(new PlayerData(nombre, value));
            string json = JsonUtility.ToJson(score);
            using (StreamWriter streamWriter = File.CreateText(dataPath))
            {
                streamWriter.Write(json);
            }
        } else { Debug.Log("no es wirteable"); }
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
        sortData();
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

    private int CompareDistanceTravelled(PlayerData a, PlayerData b)
    {
        float distance_a = a.value;
        float distance_b = b.value;
        if (distance_a < distance_b)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public void sortData()
    {
        score.scores.Sort(CompareDistanceTravelled);
        Debug.Log("sort");
    }

    public void checkData(float valueSave)
    {
        readData();
        sortData();

        if (5 < score.scores.Count)
        {
            writeable = true;
        } else if(valueSave > score.scores[4].value)
        {
            score.scores.Remove(score.scores[4]);
            writeable = true;
        }

        }

}


public class ReverserClass : IComparer<PlayerData>
{
    // Call CaseInsensitiveComparer.Compare with the parameters reversed.
    int IComparer<PlayerData>.Compare(PlayerData x, PlayerData y)
    {

         return ((new CaseInsensitiveComparer()).Compare(y.value, x.value));
        //return x.value.CompareTo(y.value);
    }
}

