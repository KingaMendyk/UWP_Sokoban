using UnityEngine;

public class MoveLeft : ICommand {
    private PlayerMovement playerMovement;
    public MoveLeft(PlayerMovement playerMovement) {
        this.playerMovement = playerMovement;
    }
    public bool Execute() {
        playerMovement.Move(Vector3.left, "walkLeft");
        return true;
    }

    public void Undo() {
        playerMovement.Move(Vector3.right, "walkRight");
    }
}