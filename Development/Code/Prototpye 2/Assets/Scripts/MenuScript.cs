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

        gameManager = GameObject.Find("GameManagerPersistent");
        gameManager.GetComponent<GameManager>();

        Debug.Log(gameManager);

        SaveManager.sm.so = SaveManager.Load();
        
        GameManager.GM.left = SaveManager.sm.so.left;
        GameManager.GM.right = SaveManager.sm.so.right;
        GameManager.GM.up = SaveManager.sm.so.up;
        GameManager.GM.down = SaveManager.sm.so.down;
        GameManager.GM.jump = SaveManager.sm.so.jump;
        GameManager.GM.shoot = SaveManager.sm.so.shoot;
        GameManager.GM.walkOrRun = SaveManager.sm.so.walkOrRun;

    }

    public void PlayGame() { //if play game button pressed then load the scene game amd destroy the menu music 
        gameManager = GameObject.Find("GameManagerPersistent");
        if (gameManager != null) gameManager.GetComponent<GameManager>().reset = true;
		SceneManager.LoadScene("Game");
    }


    public void GameSettings() //if options button pressed then load the scene options
    {
        SceneManager.LoadScene("GameSettings");
        Cursor.visible = true;
    }

    public void Exit() //if how to play button pressed then load the scene how to play
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
