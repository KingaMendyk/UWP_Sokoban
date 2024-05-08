using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, PlayerControls.IPlayerMoveActions {
    [SerializeField] private float moveSpeed = 2f;
    
    private PlayerControls playerControls;
    private Vector2 movementVector;

    private Animator animator;

    private void Awake() {
        playerControls = new PlayerControls();
        playerControls.PlayerMove.SetCallbacks(this);
        playerControls.PlayerMove.Enable();

        animator = GetComponent<Animator>();
    }

    private void Update() {
        movementVector.Normalize(); ;
        transform.Translate(movementVector * (moveSpeed * Time.deltaTime));
    }

    public void OnMoveUp(InputAction.CallbackContext context) {
        animator.SetTrigger("idle");
        movementVector = Vector2.up;
        animator.SetTrigger("walkUp");
    }

    public void OnMoveDown(InputAction.CallbackContext context) {
        animator.SetTrigger("idle");
        movementVector = Vector2.down;
        animator.SetTrigger("walkDown");
    }

    public void OnMoveLeft(InputAction.CallbackContext context) {
        animator.SetTrigger("idle");
        movementVector = Vector2.left;
        animator.SetTrigger("walkLeft");
    }

    public void OnMoveRight(InputAction.CallbackContext context) {
        animator.SetTrigger("idle");
        movementVector = Vector2.right;
        animator.SetTrigger("walkRight");
    }
}
