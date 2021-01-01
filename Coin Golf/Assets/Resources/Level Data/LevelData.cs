using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(menuName ="Level Data")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int Par;
    public int par { get { return Par; } }
    public int bestScore;

    public void SaveData()
    {
        createSaveDirectory();

        string jsonString = JsonUtility.ToJson(this);
        string path = Application.persistentDataPath + "/save/" + name + ".json";
        
        if (!File.Exists(path))
        {
            FileStream f = File.Create(path);
            f.Close();
        }
            
        File.WriteAllText(path, jsonString);
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/save/" + name + ".json"))
        {
            string jsonString = File.ReadAllText(Application.persistentDataPath + "/save/" + name + ".json");
            JsonUtility.FromJsonOverwrite(jsonString, this);
        }
    }

    void createSaveDirectory()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/save"))
            Directory.CreateDirectory(Application.persistentDataPath + "/save");
    }
}