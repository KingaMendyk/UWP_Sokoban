using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, PlayerControls.IPlayerMoveActions {
    [SerializeField] private float moveTime = 0.2f;
    [SerializeField] private int gridSize = 1;
    
    private PlayerControls playerControls;
    private Vector3 direction;

    private Animator animator;
    private bool isMoving;

    private void Awake() {
        playerControls = new PlayerControls();
        playerControls.PlayerMove.SetCallbacks(this);
        playerControls.PlayerMove.Enable();

        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (!playerControls.PlayerMove.Move.IsPressed() && !isMoving) {
            animator.SetTrigger("idle");
        }
    }

    private IEnumerator Move(Vector3 direction) {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + direction;

        float elapsedTime = 0f;
        while (elapsedTime < moveTime) {
            //TODO Animations
            animator.SetTrigger("walkUp");
            
            float percent = elapsedTime / moveTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, percent);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
        isMoving = false;
    }

    public void OnMove(InputAction.CallbackContext context) {
        if (!context.performed) 
            return;
        
        Vector2 input = playerControls.PlayerMove.Move.ReadValue<Vector2>();
        if (playerControls.PlayerMove.Move.IsPressed() && !isMoving) {
            direction = new Vector3(input.x, input.y, 0);
            StartCoroutine(Move(direction));

        }
    }
}
