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

    //public AudioSource menuMusic; //audio source that gets the background music for the menu

	void Start () {
        //get components of the buttons
		playButton = playButton.GetComponent<Button> ();
		settingsButton = settingsButton.GetComponent<Button> ();
        exitButton = exitButton.GetComponent<Button>();
        //menuMusic.Play();

        SaveManager.sm.so = SaveManager.Load();

        GameManager.GM.left = SaveManager.sm.so.left;
        GameManager.GM.right = SaveManager.sm.so.right;
        GameManager.GM.ball = SaveManager.sm.so.ball;
    }

	public void PlayGame() { //if play game button pressed then load the scene game amd destroy the menu music 
		SceneManager.LoadScene("Game");
        //Destroy(menuMusic);
	}

    //public void HighScore()  //could not get high score to work, button function still here for future updates
    //{
    //    SceneManager.LoadScene("HighScore");
    //}

    public void GameSettings() //if options button pressed then load the scene options
    {
        SceneManager.LoadScene("GameSettings");
        //SaveManager.sm.SaveUserData();
    }

    public void Exit() //if how to play button pressed then load the scene how to play
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
