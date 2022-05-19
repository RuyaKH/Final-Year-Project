using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager sm;

    public static string directory = "/SaveData/";
    public static string fileName = "MyData.json";

    public SaveObject so;

    private void Awake()
    {
        if (sm == null)
            sm = this;
        else
            Destroy(this);
        so = Load();

        if (GameManager.GM != null)
        {
            GameManager.GM.Initialise();
        }
        //GameManager.GM.Initialise();
    }

    public static void Save()
    {
        string dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(sm.so);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveObject Load()
    {
        string fullPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + directory + fileName;
        SaveObject so = new SaveObject();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveObject>(json);
        }
        else
        {
            Debug.Log("Save file does not exist");
        }

        return so;
    }
}
