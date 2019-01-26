using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{

    public Component obj;
    public SoundWaves wave;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 getPointVector(Vector3 positionSound)
    {
        Vector3 difference = positionSound - transform.position;
        Vector3 directionOnly = difference.normalized;
        Vector3 pointAlongDirection = transform.position + (directionOnly * 1f);

        return pointAlongDirection;
    }


    public void hearSound(Vector3 positionSound)
    {
        spawnWaves(positionSound);
    }

    public float getIntensity(Vector3 positionSound){
        
        float distance = Vector3.Distance(positionSound, transform.position);
        return 9 - (distance / 9) * 3;
    }

    public void spawnWaves(Vector3 positionSound)
    {


        Vector3 direction = getPointVector(positionSound);
        Debug.DrawLine(transform.position, direction, Color.red, 5);
        int intensity = (int) getIntensity(positionSound);
        if(intensity<1)
         return;
        SoundWaves obj = Instantiate<SoundWaves>(wave, transform);
        obj.transform.position = direction;
        obj.transform.LookAt(positionSound);

        obj.setIntensity(intensity);
    }
}
