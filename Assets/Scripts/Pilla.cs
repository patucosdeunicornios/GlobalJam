using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilla : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered " + other.gameObject.tag);
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("pillado");
        }
    }
}
