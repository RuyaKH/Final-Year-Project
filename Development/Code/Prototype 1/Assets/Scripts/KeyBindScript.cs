using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text left, right;

    private GameObject currentKey;

    //private Color normal = new Color(39, 171, 249, 255);
    //private Color selected = new Color(239, 116, 36, 255);

    void Start()
    {
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);

        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(keys["Left"]))
        {
            Debug.Log(keys["Left"]);
        }
        if (Input.GetKeyDown(keys["Right"]))
        {
            Debug.Log(keys["Right"]);
        }
    }

    void onGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                //currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        //if (currentKey != null)
        //{
        //    currentKey.GetComponent<Image>().color = normal;
        //}

        currentKey = clicked;
        //currentKey.GetComponent<Image>().color = selected;
    }
}
