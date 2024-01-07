using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler instance;
    public static int MENU_SCENE = 0;
    public static int MAIN_SCENE = 1;
    public string playerId;
    public string bestPlayer;
    public int bestScore;
    private string scoreFilePath;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        scoreFilePath = Application.persistentDataPath + "/bestscore.json";
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void UpdateBestScore(int score)
    {
        bestPlayer = playerId;
        bestScore = score;
    }

    class ScoreRecord
    {
        public string playerId;
        public int score;
    }
    public void SaveScore()
    {
        ScoreRecord record = new ScoreRecord
        {
            playerId = bestPlayer,
            score = bestScore
        };
        string json = JsonUtility.ToJson(record);
        File.WriteAllText(scoreFilePath, json);
    }

    public void LoadScore()
    {
        if (File.Exists(scoreFilePath))
        {
            string json = File.ReadAllText(scoreFilePath);
            ScoreRecord record = JsonUtility.FromJson<ScoreRecord>(json);
            bestPlayer = record.playerId;
            bestScore = record.score;
        }
    }

}
