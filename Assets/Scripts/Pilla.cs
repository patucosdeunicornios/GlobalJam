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
            Collider colider = this.gameObject.GetComponent<Collider>();
            colider.enabled = false;        
            agent.Stop();
            hidder.destroy();

            GameObject obj = GameObject.Find("GameManager");
            if (!obj)
            {
                return;
            }
            gameManager = obj.GetComponent<GameManager>();
            gameManager.RestChild();
        }
    }
}
