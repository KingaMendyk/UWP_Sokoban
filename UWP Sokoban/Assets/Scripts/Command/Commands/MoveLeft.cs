using UnityEngine;

public class MoveLeft : ICommand {
    private PlayerMovement playerMovement;
    private Vector3 playerPosition;
    public MoveLeft(PlayerMovement playerMovement, Vector3 position) {
        this.playerMovement = playerMovement;
        playerPosition = position;
    }
    public bool Execute() {
        if (Physics2D.OverlapPoint(playerPosition + Vector3.left, 1<<8)) // 1<<8 - Wall layer
            return false;
        playerMovement.Move(Vector3.left, "walkLeft");
        return true;
    }

    public void Undo() {
        playerMovement.Move(Vector3.right, "walkRight");
    }
}