using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ChildSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform prefab;
    public int totalChilds = 0;
    List<int> spawned = new List<int>();
    public System.Collections.Generic.List<Transform> spawners = new System.Collections.Generic.List<Transform>();

    void Start()
    {
        if (totalChilds > 0)
            spawnChilds();
    }

    int getRandomInt()
    {
        return Random.Range(0, spawners.ToArray().Length - 1);
    }
    void spawnChilds()
    {
        for (int i = 0; i < totalChilds; i++)
        {
            int position = getRandomInt();
            while (spawned.Contains(position))
            {
                position = getRandomInt();
            }

            Instantiate(prefab, spawners[position]);
            spawned.Add(position);
        }
    }

    int  getIndexSpawn(){
        int position = getRandomInt();
        while (spawned.Contains(position) && spawned.ToArray().Length < spawners.ToArray().Length)
        {
            position = getRandomInt();
        }

        return position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Transform getNewSpawn()
    {
        if(spawned.ToArray().Length >= spawners.ToArray().Length){
            Debug.Log("No more spawns");
            return null;
        }

        int position = getIndexSpawn();
        spawned.Add(position);
        return spawners[position];
    }
}
