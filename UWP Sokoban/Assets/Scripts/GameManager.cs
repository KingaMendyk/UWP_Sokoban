using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private GridGenerator gridGenerator;

    private char[,] levelArray;
    private int crateCount;
    private int currentCrateCount;

    private Target.Target target;
    
    private void Awake() {
        levelArray = LevelLoader.LoadData(textAsset);
    }
   
    private void Start() {
        gridGenerator.GenerateGrid(levelArray);
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
        
    }
}
