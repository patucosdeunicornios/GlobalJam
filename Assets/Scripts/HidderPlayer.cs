﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidderPlayer : MonoBehaviour
{
    private NoiseManager noiseManager;
    public float waitForWave = 0.1f;
    AudioSource audioSource;
    public AudioClip loseSound;

    static int materialIdx = 0;

    public List<Material> materials;
    public GameObject particleItem;


    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("makeNoise", 2.0f, 5f);
        noiseManager = (NoiseManager)FindObjectsOfType<NoiseManager>()[0];
        audioSource = GetComponent<AudioSource>();
        ChangeMaterial(materials[materialIdx % materials.ToArray().Length]);
    }

    void ChangeMaterial(Material newMat)
    {
        Renderer[] children;
        children = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = newMat;
            }
            rend.materials = mats;
        }

        materialIdx++;
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
        noiseManager.hearSound(this);
    }

    public void destroy()
    {
        GetComponent<Animator>().SetBool("lost", true);
        audioSource.PlayOneShot(loseSound);

        Vector3 thePosition;
        StartCoroutine(destroyObj());
    }


    IEnumerator destroyObj()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(particleItem, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void step()
    {

    }

}
