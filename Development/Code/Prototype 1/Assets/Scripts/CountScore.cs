using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CountScore : MonoBehaviour {

	Text scoreText;
	int scoreValue;

	// Use this for initialization
	void Awake () {
        //Set the score to zero
        GameObject score = GameObject.Find("ScoreValue");
        scoreText = score.GetComponent<Text>();
        DontDestroyOnLoad(gameObject);
        //Debug.Log(gameObject.name + " start");
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
