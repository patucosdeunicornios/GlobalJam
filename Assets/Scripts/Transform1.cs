using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            transform.position = new Vector3(15, 1.73f, 0);
        }
    }



}
