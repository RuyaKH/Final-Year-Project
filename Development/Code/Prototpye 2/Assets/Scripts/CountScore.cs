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

    public Light skyLight;

    public float scoreValueCol = 10f;
    public float scoreValueRot = 2.5f;

    public float colMin = 30;

    public float rotMin = 180;
    public float rotMax = 90;

    // Use this for initialization
    void Start () {
        //Set the score to zero
        GameObject score = GameObject.Find("ScoreValue");
        scoreText = score.GetComponent<Text>();
        //DontDestroyOnLoad(gameObject);
        Debug.Log(gameObject.name + " start");
    }

    //Alter the score
    public void UpdateScoreValue(int scoreUpdate)
    {
        //Update the score
        scoreValue += scoreUpdate;

        //Update the text of the score in the UI
        UpdateScoreText();

        float col = (colMin + scoreValue * scoreValueCol) / 255.0f;
        float rot = rotMin - scoreValue * scoreValueRot;

        if (col > 1.0f)
        {
            col = 1.0f;
        }

        if (rot < rotMax)
        {
            rot = rotMax;
        }

        skyLight.color = new Color(1.0f, col, col);
        skyLight.transform.localRotation = Quaternion.Euler(rot, 0, 90);
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
