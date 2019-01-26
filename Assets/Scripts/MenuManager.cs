using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {


    Button newGameButton, scoreButton, exitButton;

	// Use this for initialization
	void Start () {
        newGameButton = GameObject.Find("Nueva Partida").GetComponent<Button>();
        scoreButton = GameObject.Find("Score").GetComponent<Button>();
        exitButton = GameObject.Find("Exit").GetComponent<Button>();

        newGameButton.onClick.AddListener(() => NewGame());
        scoreButton.onClick.AddListener(() => LoadScores());
        exitButton.onClick.AddListener(() => Exit());

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void NewGame()
    {
        Debug.Log("Boton Juego nuevo pulsado");
        SceneManager.LoadScene("GameManager");
    }

    void LoadScores()
    {
        Debug.Log("Boton cargar scores pulsado");
    }

    void Exit()
    {
        Debug.Log("Boton Salir pulsado");
        Application.Quit();
    }

}
