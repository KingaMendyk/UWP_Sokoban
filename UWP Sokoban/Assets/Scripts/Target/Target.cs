using UnityEngine;
using UnityEngine.Events;

namespace Target {
    public class Target : MonoBehaviour {
        public UnityEvent TargetEntered;
        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.gameObject.CompareTag("Crate")) 
                return;
            other.gameObject.GetComponent<Crate.Crate>().Destroy();
            TargetEntered.Invoke();
        }
    }
}
