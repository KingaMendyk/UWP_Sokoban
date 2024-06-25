using TMPro;
using UnityEngine;

namespace UI {
    public class WinScreen : MonoBehaviour {
        [SerializeField] private TMP_Text scoreText;
        
        private Animator animator;
        private static readonly int OpenWinScreen = Animator.StringToHash("OpenWinScreen");

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        public void Open(int score) {
            scoreText.text = score.ToString();
            animator.SetTrigger(OpenWinScreen);
        }
    }
}