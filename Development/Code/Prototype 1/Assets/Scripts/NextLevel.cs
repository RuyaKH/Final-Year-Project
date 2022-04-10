using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevel : MonoBehaviour
{
    public Button nextLevelButton;
    public Button exitGameButton;

    void Start()
    {
        nextLevelButton = nextLevelButton.GetComponent<Button>();
        exitGameButton = exitGameButton.GetComponent<Button>();
    }

    public void GoNextLevel() //if options button pressed then load the scene options
    {
        Debug.Log("go next level");
        SceneManager.LoadScene("Game1");
    }

    public void GameSettings() //if options button pressed then load the scene options
    {
        SceneManager.LoadScene("GameSettings");
    }

    public void Exit()
    {
        Debug.Log("exit to main menu");
        SceneManager.LoadScene("Main Menu");
    }
}
