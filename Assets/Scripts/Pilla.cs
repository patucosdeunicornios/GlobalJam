using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pilla : MonoBehaviour
{
    public NavMeshAgent agent;
    public HidderPlayer hidder;
    public GameManager gameManager;

    void Start()
    {
        
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (!this.gameObject)
            {
                return;
            }
            Debug.Log("pillado");
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            Collider colider = this.gameObject.GetComponent<Collider>();
            colider.enabled = false;
            gameManager.RestChild();         
            agent.Stop();
            hidder.destroy();
        }
    }
}
