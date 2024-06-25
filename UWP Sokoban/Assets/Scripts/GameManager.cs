using DefaultNamespace;
using Player;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private PlayerInput playerInput;
    
    [SerializeField] private WinScreen winScreen;
    [SerializeField] private GameObject HUD;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private AudioClip winAudio;
    [SerializeField] private AudioClip targetAudio;

    private char[,] levelArray;
    private int crateCount;
    private int currentCrateCount;
    private int score;

    private Target.Target target;
    
    private void Start() {
        LoadLevel();
    }
    
    private void LoadLevel() {
        levelArray = LevelLoader.LoadData(LevelManager.GetTextAsset());
        gridGenerator.GenerateGrid(levelArray);
        crateCount = GameObject.FindGameObjectsWithTag("Crate").Length;
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Target.Target>();
        target.TargetEntered.AddListener(ChangeCrateCount);
        HUD.SetActive(true);
        currentCrateCount = 0;
        score = 0;
        scoreText.text = score.ToString();
        playerInput.LoadPlayer();
        playerInput.Enable();
    }

    private void ChangeCrateCount() {
        currentCrateCount++;
        score += 100;
        AudioManager.Instance.PlaySound(targetAudio);
        scoreText.text = score.ToString();
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

    public void ExitToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
