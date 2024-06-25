using UnityEngine;

public class GridGenerator : MonoBehaviour {
    [SerializeField] private Camera mainCamera;
    
    [Space(10)]
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    
    [Header("Prefabs")]
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject cratePrefab;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject playerPrefab;

    private char[,] charArray;
    private int width;
    private int height;

    public void GenerateGrid(char[,] array) {
        charArray = array;
        width = charArray.GetLength(0);
        height = charArray.GetLength(1);

        GenerateGrid();
        CenterCamera();
    }

    private void GenerateGrid() {
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                GameObject prefab = groundPrefab;
                Vector3 pos = new Vector3(j + j*xOffset, height - i - i*yOffset);
                char c = charArray[i, j];
                switch (c) {
                    case '.': //ground
                        prefab = groundPrefab;
                        break;
                    case '#': //wall
                        Instantiate(groundPrefab, pos, Quaternion.identity, this.transform);
                        prefab = wallPrefab;
                        break;
                    case '*': //crate
                        Instantiate(groundPrefab, pos, Quaternion.identity, this.transform);
                        prefab = cratePrefab;
                        break;
                    case 'x': //target
                        Instantiate(groundPrefab, pos, Quaternion.identity, this.transform);
                        prefab = targetPrefab;
                        break;
                    case 'o': //player
                        Instantiate(groundPrefab, pos, Quaternion.identity, this.transform);
                        prefab = playerPrefab;
                        break;
                }
                GameObject newTile = Instantiate(prefab, pos, Quaternion.identity, this.transform);
            }
        }
    }

    private void CenterCamera() {
        mainCamera.transform.position = new Vector3((float)width/2 - 0.5f, (float)height/2 - 0.5f, -10);
    }

    public void DestroyGrid() {
        foreach (Transform child in gameObject.transform) {
            Destroy(child.gameObject);
        }
    }
}
