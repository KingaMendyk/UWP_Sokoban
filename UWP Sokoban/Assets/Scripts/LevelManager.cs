using System.IO;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelManager : MonoBehaviour {
        public static LevelManager Instance;
        
        [SerializeField] private TextAsset textAsset;
        
        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
            }
            else {
                Instance = this;
            }
            DontDestroyOnLoad(this);
        }
        
        public void setTextAsset(string textAssetName) {
            textAsset = new TextAsset(File.ReadAllText("Assets/TextFiles/" + textAssetName + ".txt"));
        }

        public TextAsset getTextAsset() {
            return textAsset;
        }
    }
}