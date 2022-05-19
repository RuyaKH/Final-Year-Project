using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public Button save;
    public Button load;

    public bool keyboard = true;
    public bool controller = false;
    //public bool invert = false;
    public bool yes = false;
    public bool no = true;
    public bool ballMouse = true;
    public bool ballKeyboard = false;

    //public KeyCode left { get; set; }
    //public KeyCode right { get; set; }
    //public KeyCode ball { get; set; }

    public KeyCode left;
    public KeyCode right;
    public KeyCode ball;

    void Awake()
    {
        //SaveObject so = new SaveObject();

        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }

        //left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        //right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        //ball = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("BallDrag", "Space"));

        left = SaveManager.sm.so.left;
        right = SaveManager.sm.so.right;
        ball = SaveManager.sm.so.ball;

        no = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SaveManager.sm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
