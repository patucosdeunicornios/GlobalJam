﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    DataControler DataControler = new DataControler();

    public GameObject gameOverCanvas, gameWinCanvas;
    GameObject gameCanvas;
    public float timeLimit = 5f;
    private float currentTime;
    float timeCounter;
    bool gameOver;
    public GameObject[] kids;
    string kidsName;
    public Button restartButon, exitButton;
    Text lessTimeText, childsToFindText;
    Text scoreText;

    public int childsToFind;

    void Awake()
    {
        timeCounter = 0;
        currentTime = timeLimit;
        gameOver = false;
        
    }

    // Use this for initialization
    void Start()
    {

        gameCanvas = GameObject.Find("GameCanvas");
        kids = GameObject.FindGameObjectsWithTag("kid");
        childsToFind = kids.Length;

        lessTimeText = GameObject.Find("lessTime").GetComponent<Text>();
        lessTimeText.text = "Segundos Restante: " + currentTime.ToString();

        childsToFindText = GameObject.Find("childsToFind").GetComponent<Text>();
        childsToFindText.text = "Niños Restantes: " + childsToFind;

        restartButon.onClick.AddListener(() => { RestartGame(); });
        exitButton.onClick.AddListener(() => { exitGame(); });

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            RestChild();
        }

        if (!gameOver)
        {
            Debug.Log("Tiempo Restante: " + currentTime);
            callTime();
            lessTimeText.text = "Segundos Restante: " + currentTime.ToString();
            childsToFindText.text = "Niños Restantes: " + childsToFind;
        }
    }


    void callTime()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 1)
        {
            timeCounter = 0;
            //Restamos 1 segundo
            currentTime -= 1;
            //Mostramos el log      
            checkGame();     
        }
    }

    void checkGame()
    {
        if (currentTime <= 0)
        {
            gameCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            gameOver = true;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void exitGame()
    {
        SceneManager.LoadScene("Menu Scene");
    }


    void RestChild()
    {
        childsToFind -= 1;
        if (childsToFind <= 0)
        {
            gameOver = true;
            //int value = (int)currentTime;
            //Debug.Log(DataControler);
            DataControler.saveData("fran", currentTime);
            gameCanvas.SetActive(false);
            gameWinCanvas.SetActive(true);

            scoreText = GameObject.Find("Score").GetComponent<Text>();
            scoreText.text = "Segundos restantes: " + currentTime;
        }
    }

}
