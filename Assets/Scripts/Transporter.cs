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
        Debug.Log("entered "+other.gameObject.tag);
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("entered");
                    
            other.transform.Translate(destination.transform.position);

            HeroController hero = other.GetComponent<HeroController>();
            hero.teleport(destination.transform.position);
            // other.transform.position = destination.transform.position;
        }
    }
    
}
