using UnityEngine;

public class GridGenerator : MonoBehaviour {
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject cratePrefab;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject playerPrefab;

    private char[,] charArray;

    public void GenerateGrid(char[,] array) {
        charArray = array;
        width = charArray.GetLength(0);
        height = charArray.GetLength(1);
        
        GenerateGrid();
    }

    private void GenerateGrid() {
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                GameObject prefab = groundPrefab;
                Vector3 pos = new Vector3(j, height - i);
                char c = charArray[i, j];
                switch (c) {
                    case '.': //ground
                        prefab = groundPrefab;
                        break;
                    case '#': //wall
                        prefab = wallPrefab;
                        break;
                    case '*': //crate
                        prefab = cratePrefab;
                        break;
                    case 'X': //target
                        prefab = targetPrefab;
                        break;
                    case 'o': //player
                        prefab = playerPrefab;
                        break;
                }
                GameObject newTile = Instantiate(prefab, pos, Quaternion.identity, this.transform);
            }
        }
    }
}
