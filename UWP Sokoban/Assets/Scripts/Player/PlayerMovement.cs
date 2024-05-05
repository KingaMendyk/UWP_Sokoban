using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, PlayerControls.IPlayerMoveActions {
    [SerializeField] private float moveSpeed = 2f;
    
    private PlayerControls playerControls;
    private Vector2 movementVector;

    private void Awake() {
        playerControls = new PlayerControls();
        playerControls.PlayerMove.SetCallbacks(this);
        playerControls.PlayerMove.Enable();
    }

    private void Update() {
        movementVector.Normalize(); ;
        transform.Translate(movementVector * (moveSpeed * Time.deltaTime));
    }

    public void OnMovement(InputAction.CallbackContext context) {
        movementVector = context.ReadValue<Vector2>();
    }
}
