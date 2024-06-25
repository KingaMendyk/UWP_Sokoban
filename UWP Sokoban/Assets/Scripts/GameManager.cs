using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private GridGenerator gridGenerator;

    private char[,] levelArray;
    private int crateCount;
    private int currentCrateCount;
    
    private void Awake() {
        levelArray = LevelLoader.LoadData(textAsset);
    }
   
    private void Start() {
        gridGenerator.GenerateGrid(levelArray);
        crateCount = GameObject.FindGameObjectsWithTag("Crate").Length;
    }
    
    private void Update() {
        
    }
}
