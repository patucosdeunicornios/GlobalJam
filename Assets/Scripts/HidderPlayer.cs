using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidderPlayer : MonoBehaviour
{
    private NoiseManager noiseManager;
    public float waitForWave = 0.1f;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("makeNoise", 2.0f, 5f);
        noiseManager = (NoiseManager)FindObjectsOfType<NoiseManager>()[0];
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void makeNoise()
    {
         //AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        audioSource.PlayOneShot(audioSource.clip);
        StartCoroutine(waves());
    }

    public void onClap()
    {
        StartCoroutine(onClapDelay());
    }
    IEnumerator onClapDelay()
    {
        Debug.Log("has to clap");
        yield return new WaitForSeconds(1);
        makeNoise();
    }

    IEnumerator waves()
    {
        yield return new WaitForSeconds(waitForWave);
        noiseManager.hearSound(transform.position);
    }


}
