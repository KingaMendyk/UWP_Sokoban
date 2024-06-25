using Player;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private WinScreen winScreen;
    private PlayerInput playerInput;

    private char[,] levelArray;
    private int crateCount;
    private int currentCrateCount;

    private Target.Target target;
    
    private void Awake() {
        levelArray = LevelLoader.LoadData(textAsset);
    }
   
    private void Start() {
        gridGenerator.GenerateGrid(levelArray);
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        crateCount = GameObject.FindGameObjectsWithTag("Crate").Length;
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Target.Target>();
        target.TargetEntered.AddListener(ChangeCrateCount);
    }

    private void ChangeCrateCount() {
        currentCrateCount++;
        if (currentCrateCount == crateCount) {
            ShowWinMessage();
        }
    }

    private void ShowWinMessage() {
        playerInput.Disable();
        winScreen.Open();
    }
}
