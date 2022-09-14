using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class Back : MonoBehaviour
{
    public Button back;

    void Start()
    {
        back = back.GetComponent<Button>();
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
            BackMain();
    }

    public void BackMain()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }
}
