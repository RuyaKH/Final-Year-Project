using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSettings : MonoBehaviour
{
    //keybinding buttons
    public Button leftKey;
    public Button rightKey;
    public Button ballKey;

    public Button yesButton;
    public Button noButton;
    public Button ballMouseButton;

    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;


    void Start()
    {
        waitingForKey = false;

        leftKey.GetComponentInChildren<Text>().text = GameManager.GM.left.ToString();
        rightKey.GetComponentInChildren<Text>().text = GameManager.GM.right.ToString();
        ballKey.GetComponentInChildren<Text>().text = GameManager.GM.ball.ToString();

    }

    void Update()
    {

    }

    public void Yes()
    {
        GameManager.GM.yes = true;
        GameManager.GM.no = false;
        Debug.Log("Yes");
    }

    public void No()
    {
        GameManager.GM.no = true;
        GameManager.GM.yes = false;
        Debug.Log("No");
    }

    public void BallMouse()
    {
        GameManager.GM.ballMouse = true;
        GameManager.GM.ballKeyboard = false;
        Debug.Log("BallMouse");
    }

    public void BallKeyboard()
    {
        GameManager.GM.ballKeyboard = true;
        GameManager.GM.ballMouse = false;
        Debug.Log("BallKeyboard");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    private void OnLevelWasLoaded(int level)
    {
        LoadButton();
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
                SaveManager.sm.so.left = newKey;
                buttonText.text = SaveManager.sm.so.left.ToString();
                //GameManager.GM.left = newKey;
                //buttonText.text = GameManager.GM.left.ToString();
                //PlayerPrefs.SetString("Left", GameManager.GM.left.ToString());
                break;
            case "right":
                SaveManager.sm.so.right = newKey;
                buttonText.text = SaveManager.sm.so.right.ToString();
                break;
            case "ball":
                SaveManager.sm.so.ball = newKey;
                buttonText.text = SaveManager.sm.so.ball.ToString();
                break;
        }

        yield return null;
    }

    public void LoadButton()
    {
        SaveManager.sm.so = SaveManager.Load();

        GameManager.GM.left = SaveManager.sm.so.left;
        GameManager.GM.right = SaveManager.sm.so.right;
        GameManager.GM.ball = SaveManager.sm.so.ball;

        leftKey.GetComponentInChildren<Text>().text = GameManager.GM.left.ToString();
        rightKey.GetComponentInChildren<Text>().text = GameManager.GM.right.ToString();
        ballKey.GetComponentInChildren<Text>().text = GameManager.GM.ball.ToString();
    }

    public void SaveButton()
    {
        GameManager.GM.left = SaveManager.sm.so.left;
        GameManager.GM.right = SaveManager.sm.so.right;
        GameManager.GM.ball = SaveManager.sm.so.ball;
        SaveManager.Save(); 
    }
}
