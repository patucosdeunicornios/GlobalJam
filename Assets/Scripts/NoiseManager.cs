using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{

    public Component obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void positionObject(Vector3 positionSound)
    {
        Vector3 difference = positionSound- transform.position;
        Vector3 directionOnly = difference.normalized;
        Vector3 pointAlongDirection = transform.position + (directionOnly * 1f);
        Debug.DrawLine(transform.position, pointAlongDirection, Color.red, 5);
        obj.transform.position = pointAlongDirection;
    }


    public void hearSound(Vector3 positionSound)
    {
        Debug.Log("Escuchando...");
        positionObject(positionSound);
    }
}
