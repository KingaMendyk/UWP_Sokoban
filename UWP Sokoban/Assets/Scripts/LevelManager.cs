using System.IO;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelManager : MonoBehaviour {
        public static LevelManager Instance;
        
        private TextAsset textAsset;
        private string text;
        
        private void Awake() {
            if (Instance != null && Instance != this) {
                setTextAsset(Instance.getText());
                Destroy(gameObject);
            }
            else {
                Instance = this;
            }
            DontDestroyOnLoad(this);
        }
        
        public void setTextAsset(string textAssetName) {
            textAsset = new TextAsset(File.ReadAllText("Assets/TextFiles/" + textAssetName + ".txt"));
            text = textAssetName;
        }

        private string getText() {
            return text;
        }

        public TextAsset getTextAsset() {
            return textAsset;
        }
    }
}