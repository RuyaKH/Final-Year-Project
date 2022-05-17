using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public bool reset = false;

    public GameObject pauseMenu;

    public bool mouse = false;

    void Awake()
    {
        Debug.Log(mouse);
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
        //Debug.Log(selectedToggle.isOn);
        //selectedToggle.onValueChanged.AddListener(delegate
        //{
        //    MouseCheck(selectedToggle);
        //});
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            ResetScene();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameRunning)
            {
                //Debug.LogWarning("Pausing");
                gameRunning = false;
                if (pauseMenu != null) pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                gameRunning = true;
                if (pauseMenu != null) pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
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

    void ResetScene()
    {
        if (pauseMenu == null)
        {
            GameObject canvas = GameObject.Find("Canvas");

            if (canvas != null)
            {
                Debug.Log("Found canvas");
                pauseMenu = canvas.GetComponent<PauseMenuController>().pauseMenu;
            }
        }

        pauseMenu.SetActive(false);
        gameRunning = true;
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        reset = false;
    }
}
