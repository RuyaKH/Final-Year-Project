using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text left, right;

    private GameObject currentKey;

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
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(keys["Right"]))
        {
            Debug.Log("Right");
        }
    }

    void onGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey && e.type == EventType.KeyUp)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
}
