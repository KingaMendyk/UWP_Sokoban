using TMPro;
using UnityEngine;

namespace UI {
    public class WinScreen : MonoBehaviour {
        [SerializeField] private TMP_Text scoreText;
        
        private Animator animator;
        private static readonly int OpenWinScreen = Animator.StringToHash("OpenWinScreen");
        private static readonly int CloseWinScreen = Animator.StringToHash("CloseWinScreen");

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        public void Open(string score) {
            scoreText.text = score;
            animator.SetTrigger(OpenWinScreen);
        }

        public void Close() {
            animator.SetTrigger(CloseWinScreen);
        }
    }
}