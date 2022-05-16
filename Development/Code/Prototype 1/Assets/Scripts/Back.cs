using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        if (Input.GetButtonDown("Cancel"))
            BackMain();
    }

    public void BackMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
