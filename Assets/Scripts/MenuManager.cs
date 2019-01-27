using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    DataControler DataControler = new DataControler();
    Button newGameButton, scoreButton, exitButton, menuButton, helpButton, creditsButton;

    public Canvas canvas, canvasHelp, canvasCredits;

    // Use this for initialization
    void Start () {

        GameObject CanvasGameObject = GameObject.Find("ScoreCanvas");
        CanvasGameObject.GetComponent<Canvas>().enabled = false;

        newGameButton = GameObject.Find("Nueva Partida").GetComponent<Button>();
        scoreButton = GameObject.Find("Score").GetComponent<Button>();
        exitButton = GameObject.Find("Exit").GetComponent<Button>();
        menuButton = GameObject.Find("Menu").GetComponent<Button>();
        helpButton = GameObject.Find("Help").GetComponent<Button>();
        creditsButton = GameObject.Find("Creditos").GetComponent<Button>();

        newGameButton.onClick.AddListener(() => NewGame());
        scoreButton.onClick.AddListener(() => LoadScores());
        exitButton.onClick.AddListener(() => Exit());
        menuButton.onClick.AddListener(() => HideScores());
        newGameButton.onClick.AddListener(() => NewGame());
        helpButton.onClick.AddListener(() => HelpPage());
        creditsButton.onClick.AddListener(() => CreditsPage());

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvasHelp.gameObject.active){
                HideHelpPage();
            } else if (canvasCredits.gameObject.active)
            {
                HideCreditsPage();
            }
            
        }
	}


    void NewGame()
    {
        Debug.Log("Boton Juego nuevo pulsado");
        SceneManager.LoadScene("Nivel_V2");
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

    void HelpPage(){
        canvas.gameObject.SetActive(false);
        canvasHelp.gameObject.SetActive(true);
    }

    void HideHelpPage(){
        canvas.gameObject.SetActive(true);
        canvasHelp.gameObject.SetActive(false);
    }

    void CreditsPage(){
        canvas.gameObject.SetActive(false);
        canvasCredits.gameObject.SetActive(true);
    }

    void HideCreditsPage(){
        canvas.gameObject.SetActive(true);
        canvasCredits.gameObject.SetActive(false);
    }

}
