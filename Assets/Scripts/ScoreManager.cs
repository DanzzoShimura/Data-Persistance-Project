using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string PlayerName;

    public int Score;

    public int BestScore;
    public string BestPlayer;
    

    void Awake() {
       
       if (Instance != null)
       {
        Destroy(gameObject);
        return;
       }

       Instance = this;
       DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int Score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            BestPlayer = data.PlayerName;
            BestScore = data.Score;

        }
    }
}
