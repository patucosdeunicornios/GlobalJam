using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChild : MonoBehaviour
{

    public Transform destination;
    public NavMeshAgent agent;
    private Animator anim;

    private ChildSpawner spawner;
    private bool changed = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        spawner = FindObjectOfType<ChildSpawner>();

        if (destination)
            agent.SetDestination(destination.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", agent.velocity.magnitude );
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered "+other.gameObject.tag);
        if (other.gameObject.tag.Equals("Player") && !changed)
        {
            Debug.Log("Found you");
            changed = true;
            agent.SetDestination(spawner.getNewSpawn().position);
        }
    }



}
