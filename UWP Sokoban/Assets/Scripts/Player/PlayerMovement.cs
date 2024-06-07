using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveTime = 0.2f;
    [SerializeField] private float cellSize;
    private GameObject player;
    private Animator animator;
    private bool isMoving;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = this.player.GetComponent<Animator>();
    }
    
    private IEnumerator MoveEnumerator(Vector3 direction, string animationState) {
        isMoving = true;
        Vector3 startPosition = player.transform.position;
        Vector3 endPosition = startPosition + direction;

        float elapsedTime = 0f;
        while (elapsedTime < moveTime) {
            animator.SetTrigger(animationState);
            
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
}