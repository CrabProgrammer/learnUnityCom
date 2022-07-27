using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    public string bestName;
    public string currentName;
    public int bestScore;

    [Serializable]
    public class SavedBestScore
    {
        public string name;
        public int score;
    }
    public void SaveBestScore(int score)
    {
        SavedBestScore data = new SavedBestScore();
        data.name = currentName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedBestScore data = JsonUtility.FromJson<SavedBestScore>(json);

            bestName = data.name;
            bestScore = data.score;
        }
        else
        {
            bestName = "None";
            bestScore = 0;
        }

    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
