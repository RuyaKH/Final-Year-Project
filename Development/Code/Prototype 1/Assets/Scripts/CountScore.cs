using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CountScore : MonoBehaviour {

	Text scoreText;
	int scoreValue;

	// Use this for initialization
	void Start () {
        //Set the score to zero
        GameObject score = GameObject.Find("ScoreValue");
        scoreText = score.GetComponent<Text>();
        DontDestroyOnLoad(gameObject);
        UpdateScoreText();
        //Debug.Log(gameObject.name + " start");
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //if game over scene is loaded then update the score value and set it to game object text for game over scene, if menu loaded then destroy score
    {
        if (String.Equals(scene.name, "Game1", StringComparison.OrdinalIgnoreCase)) //if game over loaded
        {
            GameObject score = GameObject.Find("ScoreValue"); //find game object called PlayerScoreNum so it can be updated with the score value
            scoreText = score.GetComponent<Text>(); //get the text for score
            UpdateScoreText();
        }

        if (String.Equals(scene.name, "MainMenu", StringComparison.OrdinalIgnoreCase)) //if menu is loaded then destroy the game object so the score is restarted
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (scoreText == null)
        {
            GameObject score = GameObject.Find("ScoreValue");
            scoreText = score.GetComponent<Text>();
        }
    }

    //Alter the score
    public void UpdateScoreValue(int scoreUpdate)
    {
        //Update the score
        scoreValue += scoreUpdate;

        //Update the text of the score in the UI
        UpdateScoreText();
    }

    //Update the score in the game
    void UpdateScoreText()
    {
        scoreText.text = " " + scoreValue;
    }

    //Reset score to zero
    void ResetScore()
    {
        scoreValue = 0;
        UpdateScoreText();
    }


}
