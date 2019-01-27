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
    AudioSource audioSource;
    public AudioClip laught;

    private bool hasLaugh = false;
    private float timeFromLaught = 0;
    public float timeMaxLaught = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        spawner = FindObjectOfType<ChildSpawner>();
        audioSource = GetComponent<AudioSource>();

        if (destination)
            agent.SetDestination(destination.position);

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", agent.velocity.magnitude);

        if (hasLaugh)
        {
            timeFromLaught += Time.deltaTime;

            if (timeFromLaught >= timeMaxLaught)
            {
                timeFromLaught = 0;
                hasLaugh = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered " + other.gameObject.tag);
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Found you");
            if (!hasLaugh)
            {
                audioSource.PlayOneShot(laught);
                hasLaugh = true;
            }
            agent.SetDestination(spawner.getNewSpawn().position);
        }
    }



}
