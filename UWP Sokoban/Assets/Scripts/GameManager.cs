using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private GridGenerator gridGenerator;

    private char[,] levelArray;
    
    private void Awake() {
        levelArray = LevelLoader.LoadData(textAsset);
    }
   
    private void Start() {
        gridGenerator.GenerateGrid(levelArray);
    }
    
    private void Update() {
        
    }
}
