﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class NoiseManager : MonoBehaviour
{

    public SoundWaves wave;

    AudioSource audioSource;
    SoundWaves currentWave;
    HidderPlayer enemy;

     private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            clap();
        }

        if (currentWave)
        {
            followWave();
        }
    }

    void clap()
    {
        anim.Play("clap");
        audioSource.PlayOneShot(audioSource.clip);
        broadcastClap();
    }


    void broadcastClap()
    {
        HidderPlayer[] gos = (HidderPlayer[])GameObject.FindObjectsOfType(typeof(HidderPlayer));
        foreach (HidderPlayer go in gos)
        {
            go.onClap();
        }
    }

    Vector3 getPointVector(Vector3 positionSound)
    {
        Vector3 difference = positionSound - transform.position;
        Vector3 directionOnly = difference.normalized;
        Vector3 pointAlongDirection = transform.position + (directionOnly * 1f);

        return pointAlongDirection;
    }


    public void hearSound(HidderPlayer player)
    {
        spawnWaves(player);
    }

    public float getIntensity(Vector3 positionSound)
    {

        float distance = Vector3.Distance(positionSound, transform.position);
        return 9 - (distance / 9) * 3;
    }

    public void followWave()
    {
        Vector3 positionSound = enemy.transform.position;
        Vector3 direction = getPointVector(positionSound);
        currentWave.transform.position = direction;
        currentWave.transform.LookAt(positionSound);

        Debug.DrawLine(transform.position, direction, Color.red, 3f);

        int intensity = (int)getIntensity(positionSound);
        if (intensity < 1)
            return;


        currentWave.setIntensity(intensity);
    }

    public void spawnWaves(HidderPlayer player)
    {
        Vector3 positionSound = player.transform.position;
        if (currentWave && enemy)
        {
            float distanceNew = Vector3.Distance(positionSound, transform.position);
            float distanceCurrent = Vector3.Distance(enemy.transform.position, transform.position);
            if(distanceNew > distanceCurrent)
                return;
        }

        enemy = player;
        SoundWaves obj = Instantiate<SoundWaves>(wave, transform);
        currentWave = obj;
    }


    public void Palmada(){
        Debug.Log("Palmada");
    }
}
