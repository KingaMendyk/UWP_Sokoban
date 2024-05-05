using UnityEngine;

public class GridGenerator : MonoBehaviour {
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private GameObject tilePrefab;

    private void Start() {
        GenerateGrid();
    }

    private void GenerateGrid() {
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                GameObject newTile = Instantiate(tilePrefab, new Vector3(i, j), Quaternion.identity, this.transform);
            }
        }
    }
}
