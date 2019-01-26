using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    // Start is called before the first frame update
    public Component destination;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("entered");

            other.gameObject.transform.position = destination.transform.position;
        }
    }
    
}
