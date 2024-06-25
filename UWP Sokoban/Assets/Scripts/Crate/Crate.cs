using System.Collections;
using UnityEngine;

namespace Crate {
    public class Crate : MonoBehaviour {
        private Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        public void Destroy() {
            animator.SetTrigger("isDestroyed");
            StartCoroutine(WaitForAnimation());
        }

        private IEnumerator WaitForAnimation() {
            yield return new WaitForSeconds(0.3f);
            gameObject.SetActive(false);
        }
    }
}
