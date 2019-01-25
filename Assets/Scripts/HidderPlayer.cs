using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidderPlayer : MonoBehaviour
{
    public NoiseManager noiseManager;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeNoise", 2.0f, 5f);

    }

    // Update is called once per frame
    void Update()
    {

    }


    void makeNoise()
    {
        Debug.Log("Haciendo ruido");
        noiseManager.hearSound(transform.position);
    }
}
