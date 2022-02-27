using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameData : MonoBehaviour
{

    public static NameData Instance;
    public string user_name;
    public int saved_score;
    public string saved_name;
    
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int score;
        public string name;
    }

    public void SaveHighScore(int score)
    {
        if (score <= saved_score)
        {
            return;
        }
        SaveData data = new SaveData();
        data.name = user_name;
        data.score = score;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            saved_name = data.name;
            saved_score = data.score;
            
        }
    }
}
