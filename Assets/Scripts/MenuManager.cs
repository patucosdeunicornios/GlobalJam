using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    DataControler DataControler = new DataControler();
    Button newGameButton, scoreButton, exitButton, menuButton;

    // Use this for initialization
    void Start () {

        GameObject CanvasGameObject = GameObject.Find("ScoreCanvas");
        CanvasGameObject.GetComponent<Canvas>().enabled = false;

        newGameButton = GameObject.Find("Nueva Partida").GetComponent<Button>();
        scoreButton = GameObject.Find("Score").GetComponent<Button>();
        exitButton = GameObject.Find("Exit").GetComponent<Button>();
        menuButton = GameObject.Find("Menu").GetComponent<Button>();

        newGameButton.onClick.AddListener(() => NewGame());
        scoreButton.onClick.AddListener(() => LoadScores());
        exitButton.onClick.AddListener(() => Exit());
        menuButton.onClick.AddListener(() => HideScores());

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideScores();
        }
	}


    void NewGame()
    {
        Debug.Log("Boton Juego nuevo pulsado");
        SceneManager.LoadScene("GameManager");
    }

    void LoadScores()
    {
        Debug.Log("Boton cargar scores pulsado");
        DataControler.showData();
    }

    void Exit()
    {
        Debug.Log("Boton Salir pulsado");
        Application.Quit();
    }

    void HideScores()
    {
        GameObject CanvasGameObject = GameObject.Find("ScoreCanvas");
        CanvasGameObject.GetComponent<Canvas>().enabled = false;

        GameObject CanvasGameObject2 = GameObject.Find("MenuCanvas");
        CanvasGameObject2.GetComponent<Canvas>().enabled = true;
    }

}
