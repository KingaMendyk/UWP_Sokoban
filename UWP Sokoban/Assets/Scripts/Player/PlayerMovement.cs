using System.Collections;
using UnityEngine;

namespace Player {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private float moveTime = 0.2f;
        [SerializeField] private float cellSize;
        [SerializeField] private AudioClip moveClip;
        private GameObject player;
        private Animator animator;
        private bool isMoving;

        private void Awake() {
            player = GameObject.FindGameObjectWithTag("Player");
            animator = this.player.GetComponent<Animator>();
        }
    
        private IEnumerator MoveEnumerator(Vector3 direction, string animationState) {
            isMoving = true;
            animator.SetTrigger(animationState);
            AudioManager.Instance.PlaySound(moveClip);
            
            Vector3 startPosition = player.transform.position;
            Vector3 endPosition = startPosition + direction;

            float elapsedTime = 0f;
            while (elapsedTime < moveTime) {
                float percent = elapsedTime / moveTime;
                player.transform.position = Vector3.Lerp(startPosition, endPosition, percent);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            player.transform.position = endPosition;
            isMoving = false;
            animator.SetTrigger("idle");
        }

        public void Move(Vector3 direction, string animationState) {
            direction.Scale(new Vector3(cellSize, cellSize, 0));
            if(!isMoving)
                StartCoroutine(MoveEnumerator(direction, animationState));
        }

        public void Move(Vector3 direction, string animationState, GameObject colliderGameObject) {
            direction.Scale(new Vector3(cellSize, cellSize, 0));
            if(!isMoving)
                StartCoroutine(MoveEnumerator(direction, animationState, colliderGameObject));
        }

        private IEnumerator MoveEnumerator(Vector3 direction, string animationState, GameObject crate) {
            isMoving = true;
            animator.SetTrigger(animationState);
            AudioManager.Instance.PlaySound(moveClip);
            
            Vector3 startPosition = player.transform.position;
            Vector3 endPosition = startPosition + direction;

            Vector3 crateStartPosition = crate.transform.position;
            Vector3 crateEndPosition = crateStartPosition + direction;

            float elapsedTime = 0f;
            while (elapsedTime < moveTime) {
                float percent = elapsedTime / moveTime;
                player.transform.position = Vector3.Lerp(startPosition, endPosition, percent);
                crate.transform.position = Vector3.Lerp(crateStartPosition, crateEndPosition, percent);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            player.transform.position = endPosition;
            crate.transform.position = crateEndPosition;
            isMoving = false;
            animator.SetTrigger("idle");
        }
    }
}