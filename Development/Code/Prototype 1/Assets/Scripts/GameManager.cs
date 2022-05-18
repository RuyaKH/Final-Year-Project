using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    //public SaveObject so;

    public bool keyboard = true;
    public bool controller = false;
    //public bool invert = false;
    public bool yes = false;
    public bool no = true;
    public bool ballMouse = true;
    public bool ballKeyboard = false;

    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode ball { get; set; }

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

        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        ball = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("BallDrag", "Space"));

        //PlayerPrefs.Save();


        //left = (KeyCode)System.Enum.Parse(typeof(KeyCode), LoadKeys("Left","A"));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public string SaveKeys(string saveKeyName, string saveKeyCodeString) 
    //{
    //    SaveObject so = new SaveObject();
    //    so.keyName = saveKeyName;
    //    so.keyCodeString = saveKeyCodeString;

    //    return so.keyName;
    //    return so.keyCodeString;
    //}

    //public string LoadKeys(string loadKeyName, string loadKeyCodeString) 
    //{
    //    SaveObject so = new SaveObject();
    //    so.keyName = loadKeyName;
    //    so.keyCodeString = loadKeyCodeString;

    //    return so.keyName;
    //    return so.keyCodeString;
    //}
}
