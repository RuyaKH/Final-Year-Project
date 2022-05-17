using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
//using TMPro;

public class GameSettings : MonoBehaviour
{
    public Transform keyboardPanel;
    public Transform controllerPanel;
    public Button leftKey;
    public Button rightKey;
    public Button upKey;
    public Button downKey;
    public Button shootKey;
    public Button jumpKey;
    public Button walkKey;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;
    //public TextMeshProUGUI output;

    bool waitingForKey;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if (GameManager.GM.keyboard == true)
        {
            keyboardPanel.gameObject.SetActive(true);
            controllerPanel.gameObject.SetActive(false);
        }
        else if (GameManager.GM.controller == true)
        {
            keyboardPanel.gameObject.SetActive(false);
            controllerPanel.gameObject.SetActive(true);
        }

        waitingForKey = false;
        
        leftKey.GetComponentInChildren<Text>().text = GameManager.GM.left.ToString();
        rightKey.GetComponentInChildren<Text>().text = GameManager.GM.right.ToString();
        upKey.GetComponentInChildren<Text>().text = GameManager.GM.up.ToString();
        downKey.GetComponentInChildren<Text>().text = GameManager.GM.down.ToString();
        shootKey.GetComponentInChildren<Text>().text = GameManager.GM.shoot.ToString();
        jumpKey.GetComponentInChildren<Text>().text = GameManager.GM.jump.ToString();
        walkKey.GetComponentInChildren<Text>().text = GameManager.GM.walkOrRun.ToString();
    }

    void Update()
    {
        if (GameManager.GM.keyboard == true)
        {
            keyboardPanel.gameObject.SetActive(true);
            controllerPanel.gameObject.SetActive(false);
        }
        else if (GameManager.GM.controller == true)
        {
            keyboardPanel.gameObject.SetActive(false);
            controllerPanel.gameObject.SetActive(true);
        }
    }

    //void HandleInputData(int val)
    //{
    //    if(val == 0)
    //    {
    //        GameManager.GM.keyboard == true;
    //    }
    //}

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
            case "up":
                GameManager.GM.up = newKey;
                buttonText.text = GameManager.GM.up.ToString();
                PlayerPrefs.SetString("Up", GameManager.GM.up.ToString());
                break;
            case "down":
                GameManager.GM.down = newKey;
                buttonText.text = GameManager.GM.down.ToString();
                PlayerPrefs.SetString("Down", GameManager.GM.down.ToString());
                break;
            case "shoot":
                if (newKey == KeyCode.Tab) GameManager.GM.mouse = true;
                else
                {
                    GameManager.GM.mouse = false;
                    GameManager.GM.shoot = newKey;
                    buttonText.text = GameManager.GM.shoot.ToString();
                    PlayerPrefs.SetString("Shoot", GameManager.GM.shoot.ToString());
                }
                break;
            case "jump":
                GameManager.GM.jump = newKey;
                buttonText.text = GameManager.GM.jump.ToString();
                PlayerPrefs.SetString("Jump", GameManager.GM.jump.ToString());
                break;
            case "walkOrRun":
                GameManager.GM.walkOrRun = newKey;
                buttonText.text = GameManager.GM.walkOrRun.ToString();
                PlayerPrefs.SetString("Walk/Run", GameManager.GM.walkOrRun.ToString());
                break;
        }

        yield return null;
    }
}
