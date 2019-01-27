using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour
{

    DataControler DataControler = new DataControler();
    private GameObject gameController;

    public GameObject gameOverCanvas, gameWinCanvas;
    GameObject gameCanvas;
    public float timeLimit = 5f;
    private float currentTime;
    float timeCounter;
    bool gameOver;
    public GameObject[] kids;
    string kidsName;
    public Button restartButon, exitButton;
    public InputField InputNameField;
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
        InputNameField.onEndEdit.AddListener(delegate { endGame(); });

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Debug.Log("Tiempo Restante: " + currentTime);
            callTime();
            lessTimeText.text = "Restart Seconds: " + currentTime.ToString();
            childsToFindText.text = "Restarts Kids: " + childsToFind;
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
            //gameController = GameObject.FindGameObjectWithTag("GameController");
            //Destroy(gameController);
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


    void RestChild(Vector3 position)
    {

        if (position != Vector3.zero)
        {
            // Instantiate(particleItem, transform);
        }

        childsToFind -= 1;
        currentTime += 50;
        if (childsToFind <= 0)
        {
            gameOver = true;
            //int value = (int)currentTime;
            //Debug.Log(DataControler);
            gameCanvas.SetActive(false);
            
            if (DataControler.getWriteable(currentTime))
            {
                gameWinCanvas.SetActive(true);
            } else
            {
                exitGame();
            }

            scoreText.text = "Segundos restantes: " + currentTime;
        }
    }

    void endGame()
    {
        string name = InputNameField.text.ToString();

        DataControler.saveData(name, currentTime);
        scoreText = GameObject.Find("Score").GetComponent<Text>();

        exitGame();
    }


}
