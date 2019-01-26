using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidderPlayer : MonoBehaviour
{
    private NoiseManager noiseManager;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeNoise", 2.0f, 5f);
        noiseManager = (NoiseManager) FindObjectsOfType<NoiseManager>()[0];

    }

    // Update is called once per frame
    void Update()
    {

    }


    void makeNoise()
    {
        noiseManager.hearSound(transform.position);
    }
}
