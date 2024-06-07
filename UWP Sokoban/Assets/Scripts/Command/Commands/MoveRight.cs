using UnityEngine;

public class MoveRight : ICommand {
    private PlayerMovement playerMovement;
    public MoveRight(PlayerMovement playerMovement) {
        this.playerMovement = playerMovement;
    }
    public bool Execute() {
        playerMovement.Move(Vector3.right, "walkRight");
        return true;
    }

    public void Undo() {
        playerMovement.Move(Vector3.left, "walkLeft");
    }
}