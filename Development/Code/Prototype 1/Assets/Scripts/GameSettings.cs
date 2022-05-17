﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSettings : MonoBehaviour
{
    public Transform menuPanel;
    public Button leftKey;
    public Button rightKey;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;
    
    void Start()
    {
        //menuPanel = transform.Find("Panel");
        waitingForKey = false;

        leftKey.GetComponentInChildren<Text>().text = GameManager.GM.left.ToString();
        rightKey.GetComponentInChildren<Text>().text = GameManager.GM.right.ToString();
    }

    void Update()
    {

    }

    void OnGUI()
    {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(Text text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return WaitForKey();
        Debug.Log(keyName);
        switch(keyName)
        {
            case "left":
                GameManager.GM.left = newKey;
                buttonText.text = GameManager.GM.left.ToString();
                PlayerPrefs.SetString("Left", GameManager.GM.left.ToString());
                break;
            case "right":
                GameManager.GM.right = newKey;
                buttonText.text = GameManager.GM.right.ToString();
                PlayerPrefs.SetString("Right", GameManager.GM.right.ToString());
                break;
        }

        yield return null;
    }
}
