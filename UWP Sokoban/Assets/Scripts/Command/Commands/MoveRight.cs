using UnityEngine;

public class MoveRight : ICommand {
    private PlayerMovement playerMovement;
    private Vector3 playerPosition;
    public MoveRight(PlayerMovement playerMovement, Vector3 position) {
        this.playerMovement = playerMovement;
        playerPosition = position;
    }
    public bool Execute() {
        if (Physics2D.OverlapPoint(playerPosition + Vector3.right, 1<<8)) // 1<<8 - Wall layer
            return false;
        playerMovement.Move(Vector3.right, "walkRight");
        return true;
    }

    public void Undo() {
        playerMovement.Move(Vector3.left, "walkLeft");
    }
}