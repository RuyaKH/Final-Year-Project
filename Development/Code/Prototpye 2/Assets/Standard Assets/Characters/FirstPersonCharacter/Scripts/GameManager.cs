using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public bool keyboard;
    public bool controller;

    public KeyCode jump { get; set; }
    public KeyCode up { get; set; }
    public KeyCode down { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode shoot { get; set; }
    public KeyCode walkOrRun { get; set; }

    public bool gameRunning = true;

    public GameObject pauseMenu;

    void Awake()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }

        keyboard = true;
        controller = false;

        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));
        up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W"));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        shoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Shoot", "LeftControl"));
        walkOrRun = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Walk/Run", "LeftShift"));

        Debug.LogError("Awake");
        if (pauseMenu == null) pauseMenu = GameObject.Find("Pause");
        gameRunning = true;
        if (pauseMenu != null) pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //Debug.LogWarning("Pausing");
            gameRunning = false;
            if (pauseMenu != null ) pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            
        }
        //else
        //{
        //    if (pauseMenu == null) pauseMenu = GameObject.Find("Pause");
        //    gameRunning = true;
        //    if (pauseMenu != null) pauseMenu.SetActive(false);
        //    Time.timeScale = 1f;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}

        //if(Input.GetKey(KeyCode.P))
        //{
        //    gameRunning = true;
        //}
    }

    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            keyboard = true;
            controller = false;
        }
        if (val == 1)
        {
            controller = true;
            keyboard = false;
        }
    }

    public void FlagForReset()
    {
        if (pauseMenu == null) pauseMenu = GameObject.Find("Pause");
        gameRunning = true;
        if (pauseMenu != null) pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
