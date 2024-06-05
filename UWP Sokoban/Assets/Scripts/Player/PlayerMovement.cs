using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, PlayerControls.IPlayerMoveActions {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int gridSize = 1;
    
    private PlayerControls playerControls;
    private Vector3 movementVector;

    private Animator animator;
    private bool isMoving;

    private void Awake() {
        playerControls = new PlayerControls();
        playerControls.PlayerMove.SetCallbacks(this);
        playerControls.PlayerMove.Enable();

        animator = GetComponent<Animator>();
    }

    private IEnumerator Move(Vector3 direction) {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + direction;

        float elapsedTime = 0f;
        while (elapsedTime < (1/moveSpeed)) {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveSpeed;

            transform.position = Vector3.Lerp(startPosition, endPosition, percent);
            yield return null;
        }

        transform.position = endPosition;
        isMoving = false;
    }

    public void OnMoveUp(InputAction.CallbackContext context) {
        if (context.performed && !isMoving) {
            movementVector = Vector3.up;
            movementVector.Normalize();
            StartCoroutine(Move(movementVector));
            //animator.SetTrigger("walkUp");
        }
    }

    public void OnMoveDown(InputAction.CallbackContext context) {
        if (context.performed && !isMoving) {
            movementVector = Vector3.down;
            movementVector.Normalize();
            StartCoroutine(Move(movementVector));
            //animator.SetTrigger("walkDown");
        }
    }

    public void OnMoveLeft(InputAction.CallbackContext context) {
        if (context.performed && !isMoving) {
            movementVector = Vector3.left;
            movementVector.Normalize();
            StartCoroutine(Move(movementVector));
            //animator.SetTrigger("walkLeft");
        }
    }

    public void OnMoveRight(InputAction.CallbackContext context) {
        if (context.performed && !isMoving) {
            movementVector = Vector3.right;
            movementVector.Normalize();
            StartCoroutine(Move(movementVector));
            //animator.SetTrigger("walkRight");
        }
    }
}
