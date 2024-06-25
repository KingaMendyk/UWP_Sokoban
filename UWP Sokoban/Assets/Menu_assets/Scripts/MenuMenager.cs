using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
    using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMenager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
