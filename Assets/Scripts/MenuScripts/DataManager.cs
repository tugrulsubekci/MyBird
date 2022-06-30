using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int playerIndex;

    public string playerName;
    public int highScore;

    public TextMeshProUGUI highScoreTitle;
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
        RefreshScoreTitle();
    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bestscorefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/bestscorefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highScore = data.highScore;
        }
    }
    public void RefreshScoreTitle() // ABSTRACTION
    {
        highScoreTitle.text = $"High Score | {playerName} | {highScore}";
    }
}
