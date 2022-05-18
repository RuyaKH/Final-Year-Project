using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveTest : MonoBehaviour
{
    public SaveObject so;
    public Button save;
    public Button load;


    private void Update()
    {

    }

    public void SaveButton()
    {
        SaveManager.Save(so);
    }

    public void LoadButton()
    {
        so = SaveManager.Load();
    }
}
