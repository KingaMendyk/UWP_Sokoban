using Command;
using Command.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerInput : MonoBehaviour, PlayerControls.IPlayerMoveActions {
        private PlayerControls playerControls;
        private CommandInvoker commandInvoker;
        [SerializeField] private PlayerMovement playerMovement;

        private void Awake() {
            playerControls = new PlayerControls();
            playerControls.PlayerMove.SetCallbacks(this);
            playerControls.PlayerMove.Enable();
            commandInvoker = new CommandInvoker();
        }

        public void OnMoveUp(InputAction.CallbackContext context) {
            if (context.performed) {
                ICommand moveUpCommand = new MoveUp(playerMovement, transform.position);
                commandInvoker.ExecuteCommand(moveUpCommand);
            }
        }

        public void OnMoveDown(InputAction.CallbackContext context) {
            if (context.performed) {
                ICommand moveDownCommand = new MoveDown(playerMovement, transform.position);
                commandInvoker.ExecuteCommand(moveDownCommand);
            }
        }

        public void OnMoveLeft(InputAction.CallbackContext context) {
            if (context.performed) {
                ICommand moveLeftCommand = new MoveLeft(playerMovement, transform.position);
                commandInvoker.ExecuteCommand(moveLeftCommand);
            }
        }

        public void OnMoveRight(InputAction.CallbackContext context) {
            if (context.performed) {
                ICommand moveRightCommand = new MoveRight(playerMovement, transform.position);
                commandInvoker.ExecuteCommand(moveRightCommand);
            }
        }

        public void OnUndo(InputAction.CallbackContext context) {
            if (context.performed) {
                commandInvoker.UndoCommand();
            }
        }

        public void OnRedo(InputAction.CallbackContext context) {
            if (context.performed) {
                commandInvoker.RedoCommand();
            }
        }

        public void Enable() {
            playerControls.PlayerMove.Enable();
        }

        public void Disable() {
            playerControls.PlayerMove.Disable();
        }
    }
}
