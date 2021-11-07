using UnityEngine;
using System.IO;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;
    string currentPlayerName;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string cpn)
    {
        currentPlayerName = cpn;
    }

    public string GetPlayerName()
    {
        return currentPlayerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }

    public void SaveHighScore(string name, int score)
    {
        SaveData data = new SaveData();
        data.name = name;
        data.highScore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public string GetNameFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data.name;
        }
        else
        {
            return "";
        }
    }

    public int GetHighScoreFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data.highScore;
        }
        else
        {
            return 0;
        }
    }
}