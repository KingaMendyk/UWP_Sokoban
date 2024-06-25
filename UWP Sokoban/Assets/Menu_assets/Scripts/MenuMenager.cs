
    using DefaultNamespace;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    namespace Menu_assets.Scripts {
    public class MenuMenager : MonoBehaviour {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject levelSelector;

        public void Awake() {
            mainMenu.SetActive(true);
            levelSelector.SetActive(false);
        }
        
        public void ExitClicked() {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public void StartClicked() {
            mainMenu.SetActive(false);
            levelSelector.SetActive(true);
        }
        
        public void LoadLevel(string fileName) {
            LevelManager.SetTextAsset(fileName);
            SceneManager.LoadScene("MainGame");
        }

        public void MenuClicked() {
            mainMenu.SetActive(true);
            levelSelector.SetActive(false);
        }
    }
}
