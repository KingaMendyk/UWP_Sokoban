using System;
using System.IO;
using Player;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private WinScreen winScreen;
    [SerializeField] private GameObject HUD;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private AudioClip winAudio;
    [SerializeField] private AudioClip targetAudio;
    
    private PlayerInput playerInput;

    private char[,] levelArray;
    private int crateCount;
    private int currentCrateCount;

    private Target.Target target;

    private string scoreSavePath = "/score.txt";
    
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
        DontDestroyOnLoad(this);
        LoadLevel();
    }
    
    private void LoadLevel() {
        levelArray = LevelLoader.LoadData(textAsset);
        gridGenerator.GenerateGrid(levelArray);
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        crateCount = GameObject.FindGameObjectsWithTag("Crate").Length;
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Target.Target>();
        target.TargetEntered.AddListener(ChangeCrateCount);
        HUD.SetActive(true);
        LoadScore();
    }

    private void ChangeCrateCount() {
        currentCrateCount++;
        AudioManager.Instance.PlaySound(targetAudio);
        scoreText.text = (100 * currentCrateCount).ToString();
        if (currentCrateCount == crateCount) {
            ShowWinMessage();
        }
    }

    private void ShowWinMessage() {
        HUD.SetActive(false);
        playerInput.Disable();
        winScreen.Open(scoreText.text);
        AudioManager.Instance.PlaySound(winAudio);
    }

    public void StartOver() {
        gridGenerator.DestroyGrid();
        LoadLevel();
    }

    public void NextLevel() {
        SaveScore();
        currentCrateCount = 0;
        textAsset = new TextAsset(File.ReadAllText("Assets/TextFiles/level_map_2.txt"));
        winScreen.Close();
        gridGenerator.DestroyGrid();
        LoadLevel();
    }

    public void ExitToMenu() {
        SaveScore();
        SceneManager.LoadScene("Menu");
    }

    private void SaveScore() {
        string path = Application.persistentDataPath + scoreSavePath;

        try {
            if(File.Exists(path))
                File.Delete(path);
            FileStream stream = File.Create(path);
            stream.Close();
            File.WriteAllText(path, (100 * currentCrateCount).ToString());
        }
        catch (Exception e) {
            Debug.LogError("Unable to save data due to " + e.Message + " " + e.StackTrace);
        }
    }

    private void LoadScore() {
        string path = Application.persistentDataPath + scoreSavePath;
        if (!File.Exists(path)) {
            Debug.Log("File not exists");
            return;
        }

        try {
            string data = File.ReadAllText(path);
            scoreText.text = data;
        }
        catch (Exception e) {
            Debug.LogError("Unable to load data due to " + e.Message + " " + e.StackTrace);
        }
    }
    
    public void setTextAsset(string textAssetName) {
        textAsset = new TextAsset(File.ReadAllText("Assets/TextFiles/" + textAssetName + ".txt"));
    }
}
