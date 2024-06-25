using UnityEngine;

namespace Target {
    public class Target : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Crate")) {
                other.gameObject.GetComponent<Crate.Crate>().Destroy();
            }
        }
    }
}
