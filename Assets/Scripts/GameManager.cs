using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string playerName;
    public int highScore;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
    }
    public void StartGame(string newName)
    {
        playerName = newName;
        SceneManager.LoadScene(1);
    }
    class SaveData
    {
        public int highscore;
    }
    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.highscore = highScore;
        string dataJson = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", dataJson);
    }
    private void LoadHighscore()
    {
        if (!File.Exists(Application.persistentDataPath + "/saveData.json"))
            return;
        string dataJson = File.ReadAllText(Application.persistentDataPath + "/saveData.json");
        SaveData data = JsonUtility.FromJson<SaveData>(dataJson);
        highScore = data.highscore;
    }
}
