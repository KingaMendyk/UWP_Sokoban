
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    namespace Menu_assets.Scripts {
    public class MenuMenager : MonoBehaviour {
        public void ExitClicked() {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public void StartClicked() {
            SceneManager.LoadScene("MainGame");
        }
    }
}
