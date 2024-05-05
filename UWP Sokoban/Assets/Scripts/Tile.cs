using UnityEngine;

[CreateAssetMenu(menuName = "Tile", fileName = "Tile")]
public class Tile : ScriptableObject {
    [SerializeField] private Color color;
    [SerializeField] private Sprite sprite;
}