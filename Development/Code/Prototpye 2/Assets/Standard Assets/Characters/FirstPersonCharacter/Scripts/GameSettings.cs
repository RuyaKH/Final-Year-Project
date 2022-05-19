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

    public Button shootMouse;

    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

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

    public void ShootMouse()
    {
        GameManager.GM.mouse = true;
        Debug.Log("Shoot mouse");
    }

    public void ShootKeyboard()
    {
        GameManager.GM.mouse = false;
        Debug.Log("Shoot keyboard");
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
            case "up":
                SaveManager.sm.so.up = newKey;
                buttonText.text = SaveManager.sm.so.up.ToString();
                break;
            case "down":
                SaveManager.sm.so.down = newKey;
                buttonText.text = SaveManager.sm.so.down.ToString();
                break;
            case "shoot":
                SaveManager.sm.so.shoot = newKey;
                buttonText.text = SaveManager.sm.so.shoot.ToString();
                break;
            case "jump":
                SaveManager.sm.so.jump = newKey;
                buttonText.text = SaveManager.sm.so.jump.ToString();
                break;
            case "walkOrRun":
                SaveManager.sm.so.walkOrRun = newKey;
                buttonText.text = SaveManager.sm.so.walkOrRun.ToString();
                break;
        }

        yield return null;
    }

    public void LoadButton()
    {
        SaveManager.sm.so = SaveManager.Load();

        SaveToGameManager();

        leftKey.GetComponentInChildren<Text>().text = GameManager.GM.left.ToString();
        rightKey.GetComponentInChildren<Text>().text = GameManager.GM.right.ToString();
        upKey.GetComponentInChildren<Text>().text = GameManager.GM.up.ToString();
        downKey.GetComponentInChildren<Text>().text = GameManager.GM.down.ToString();
        jumpKey.GetComponentInChildren<Text>().text = GameManager.GM.jump.ToString();
        shootKey.GetComponentInChildren<Text>().text = GameManager.GM.shoot.ToString();
        walkKey.GetComponentInChildren<Text>().text = GameManager.GM.walkOrRun.ToString();
    }

    public void SaveButton()
    {
        SaveToGameManager();
        SaveManager.Save();
    }

    void SaveToGameManager()
    {
        GameManager.GM.left = SaveManager.sm.so.left;
        GameManager.GM.right = SaveManager.sm.so.right;
        GameManager.GM.up = SaveManager.sm.so.up;
        GameManager.GM.down = SaveManager.sm.so.down;
        GameManager.GM.jump = SaveManager.sm.so.jump;
        GameManager.GM.shoot = SaveManager.sm.so.shoot;
        GameManager.GM.walkOrRun = SaveManager.sm.so.walkOrRun;
    }
}
