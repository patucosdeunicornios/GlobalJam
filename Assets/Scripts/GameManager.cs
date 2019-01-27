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
    public Button restartButon, exitButton, exitButtonWin;
    public InputField InputNameField;
    Text lessTimeText, childsToFindText;
    Text scoreText;
    public ChildSpawner childSpawner;

    public int childsToFind;

    void Awake()
    {
        //timeCounter = 0;
        //currentTime = timeLimit;
        gameOver = false;

    }

    // Use this for initialization
    void Start()
    {
        if (exitButtonWin == true){
            exitButtonWin.gameObject.SetActive(false);
        }
        
        timeCounter = 0;
        currentTime = timeLimit;

        gameCanvas = GameObject.Find("GameCanvas");
        //kids = GameObject.FindGameObjectsWithTag("Enemy");
        childsToFind = childSpawner.getChilds();

        lessTimeText = GameObject.Find("lessTime").GetComponent<Text>();
        lessTimeText.text = "Segundos Restante: " + currentTime.ToString();

        childsToFindText = GameObject.Find("childsToFind").GetComponent<Text>();
        childsToFindText.text = "Niños Restantes: " + childsToFind;

        

        restartButon.onClick.AddListener(() => { RestartGame(); });
        exitButton.onClick.AddListener(() => { exitGame(); });
        InputNameField.onEndEdit.AddListener(delegate { endGame(); });
        exitButtonWin.onClick.AddListener(() => { exitGame(); });

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            //Debug.Log("Tiempo Restante: " + currentTime);
            callTime();
            lessTimeText.text = "Seconds less: " + currentTime.ToString();
            childsToFindText.text = "second less: " + childsToFind;
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
            GameObject hero = GameObject.FindGameObjectWithTag("Player");
            hero.SetActive(false);
            //gameController = GameObject.FindGameObjectWithTag("GameController");
            //Destroy(gameController);
            gameCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            gameOver = true;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    void exitGame()
    {
        SceneManager.LoadScene("Menu Scene");
    }


    public void RestChild()
    {

       // if (position != Vector3.zero)
       // {
            // Instantiate(particleItem, transform);
       // }

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
                scoreText = GameObject.Find("Score").GetComponent<Text>();
                scoreText.text = "seconds less: " + currentTime;
            } else
            {    
                gameWinCanvas.SetActive(true);
                scoreText = GameObject.Find("Score").GetComponent<Text>();
                scoreText.text = "seconds less: " + currentTime;
                InputNameField.gameObject.SetActive(false);
                exitButtonWin.gameObject.SetActive(true);
            }

            
        }
    }

    void endGame()
    {
        
        string name = InputNameField.text.ToString();

        DataControler.saveData(name, currentTime);
        

        exitGame();
    }


}
