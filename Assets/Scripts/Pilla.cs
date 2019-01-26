using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pilla : MonoBehaviour
{
    public NavMeshAgent agent;

    void Start()
    {
        
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("pillado");
            agent.Stop();
        }
    }
}
