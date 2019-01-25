using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject gameOverCanvas;
    public float timeLimit = 5f;
    private float currentTime;
    float timeCounter;
    bool gameOver;
    public GameObject[] kids;
    string kidsName;
    public Button restartButon, exitButton;

    void Awake()
    {
        timeCounter = 0;
        currentTime = timeLimit;
        gameOver = false;
    }

    // Use this for initialization
    void Start () {

        kids = GameObject.FindGameObjectsWithTag("kid");

        foreach (GameObject counterKids in kids)
        {
            kidsName += counterKids.name+", ";
        }

        Debug.Log("Niños a buscar: " + kidsName);


        restartButon.onClick.AddListener(() => { RestartGame(); });
        exitButton.onClick.AddListener(() => { exitGame(); });
    }
	
	// Update is called once per frame
	void Update () {

        if (!gameOver)
        {

            Debug.Log("Tiempo Restante: " + currentTime);
            callTime();
            checkGame();
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
        }
    }

    void checkGame()
    {
        if (currentTime <= 0)
        {
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


   

}
