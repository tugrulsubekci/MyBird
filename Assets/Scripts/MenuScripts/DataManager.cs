using UnityEngine;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int playerIndex;
    public bool isMusicOn;

    public string playerName;
    public int highScore;
    public int numberOfGame;

    public TextMeshProUGUI highScoreTitle;
    void Awake()
    {
        Application.targetFrameRate = 60;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        // File.Delete(Application.persistentDataPath + "/bestscorefile.json"); // This line can be activated, If you want to delete save file.
        LoadHighScore();
        isMusicOn = true;
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
}
