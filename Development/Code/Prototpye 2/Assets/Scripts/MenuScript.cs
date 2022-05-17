using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    //various buttons for menu
	public Button playButton;
	public Button settingsButton;
    public Button exitButton;

    GameObject gameManager;

	void Start () {
        //get components of the buttons
		playButton = playButton.GetComponent<Button> ();
		settingsButton = settingsButton.GetComponent<Button> ();
        exitButton = exitButton.GetComponent<Button>();

	}

	public void PlayGame() { //if play game button pressed then load the scene game amd destroy the menu music 
        gameManager = GameObject.Find("GameManagerPersistent");
        gameManager.GetComponent<GameManager>().FlagForReset();
		SceneManager.LoadScene("Game");
    }


    public void GameSettings() //if options button pressed then load the scene options
    {
        SceneManager.LoadScene("GameSettings");
    }

    public void Exit() //if how to play button pressed then load the scene how to play
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
