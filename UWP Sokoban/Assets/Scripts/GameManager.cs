using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private GridGenerator gridGenerator;

    private char[,] levelArray;
    
    private void Awake() {
        levelArray = LevelLoader.LoadData(textAsset);
    }
   
    void Start() {
        gridGenerator.GenerateGrid(levelArray);
    }
    
    void Update() {
        
    }
}
