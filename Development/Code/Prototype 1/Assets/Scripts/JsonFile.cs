using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
//using UnityEngine.JSONSerializeModule;

public class JsonFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string LoadJsonFile(string path, bool resource)
    {
        if(resource)
        {
            return LoadJsonResource(path);
        }
        else
        {
            return LoadJsonExternalResource(path);
        }
    }

    public static string LoadJsonResource(string path)
    {
        string JsonFilePath = path.Replace(".json", "");
        TextAsset loadedJsonFile = Resources.Load<TextAsset>(JsonFilePath);
        return loadedJsonFile.text;
    }

    public static string LoadJsonExternalResource(string path)
    {
        path = Application.persistentDataPath + "/" + path;

        if (!File.Exists(path))
        {
            return string.Empty;
        }

        StreamReader reader = new StreamReader(path);
        string response = "";
        while (!reader.EndOfStream)
        {
            response += reader.ReadLine();
        }

        reader.Close();
        return response;
    }

    public static void WriteJsontoExternalResource(string path, string content)
    {
        path = Application.persistentDataPath + "/" + path;

        if (!File.Exists(path))
        {
            FileStream stream = File.Create(path);
            byte[] contentBytes = new UTF8Encoding(true).GetBytes(content);

            stream.Write(contentBytes, 0, contentBytes.Length);
            stream.Close();
        }
        else
        {
            File.Delete(path);
            byte[] contentBytes = new UTF8Encoding(true).GetBytes(content);
            FileStream stream = File.OpenWrite(path);
            stream.Write(contentBytes, 0, contentBytes.Length);
            stream.Close();
        }
    }
}
