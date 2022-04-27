using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CountScore : MonoBehaviour {

	public Text scoreText;
	[SerializeField]
	public int scoreValue;
	[SerializeField]

	// Use this for initialization
	void Start () {
        //Set the score to zero
        GameObject score = GameObject.Find("ScoreValue");
        scoreText = score.GetComponent<Text>();
        DontDestroyOnLoad(gameObject);
        Debug.Log(gameObject.name + " start");
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
