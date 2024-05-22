using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, PlayerControls.IPlayerMoveActions {
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int gridSize = 1;
    
    private PlayerControls playerControls;
    private Vector2 movementVector;

    private Animator animator;
    private bool isMoving;

    private void Awake() {
        playerControls = new PlayerControls();
        playerControls.PlayerMove.SetCallbacks(this);
        playerControls.PlayerMove.Enable();

        animator = GetComponent<Animator>();
    }

    private void Update() {
        movementVector.Normalize();
        if (!isMoving)
            StartCoroutine(Move(movementVector));
    }

    private IEnumerator Move(Vector2 direction) {
        isMoving = true;
        Vector2 endPosition = (Vector2)transform.position + (direction * gridSize);

        float elapsedTime = 0f;
        while (elapsedTime < moveSpeed) {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveSpeed;

            transform.position = Vector2.Lerp(transform.position, endPosition, percent);
            yield return null;
        }

        transform.position = endPosition;
        movementVector = Vector3.zero;

        isMoving = false;
    }

    public void OnMoveUp(InputAction.CallbackContext context) {
        if (context.performed) {
            movementVector = Vector2.up;
            animator.SetTrigger("walkUp");
        }
    }

    public void OnMoveDown(InputAction.CallbackContext context) {
        if (context.performed) {
            movementVector = Vector2.down;
            animator.SetTrigger("walkDown");
        }
    }

    public void OnMoveLeft(InputAction.CallbackContext context) {
        if (context.performed) {
            movementVector = Vector2.left;
            animator.SetTrigger("walkLeft");
        }
    }

    public void OnMoveRight(InputAction.CallbackContext context) {
        if (context.performed) {
            movementVector = Vector2.right;
            animator.SetTrigger("walkRight");
        }
    }
}
