using UnityEngine;

namespace UI {
    public class WinScreen : MonoBehaviour {
        private Animator animator;
        private static readonly int OpenWinScreen = Animator.StringToHash("OpenWinScreen");

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        public void Open() {
            animator.SetTrigger(OpenWinScreen);
        }
    }
}