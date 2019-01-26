using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public string name;
    public float value;

    public PlayerData(string name, float value)
    {
        this.name = name;
        this.value = value;
       
    }

 
}

public class Score
{


    public List<PlayerData> scores = new List<PlayerData>();

    
    public Score()
    {

    }

    public Score(List<PlayerData> data)
    {
        scores = data;

    }

    public void addData(PlayerData player) {
        scores.Add(player);
     }

    public System.Collections.IEnumerator GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

 
}


