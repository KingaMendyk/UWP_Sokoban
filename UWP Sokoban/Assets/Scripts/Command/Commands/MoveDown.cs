using UnityEngine;

public class MoveDown : ICommand{
    private PlayerMovement playerMovement;
    private Vector3 playerPosition;
    public MoveDown(PlayerMovement playerMovement, Vector3 position) {
        this.playerMovement = playerMovement;
        playerPosition = position;
    }
    public bool Execute() {
        if (Physics2D.OverlapPoint(playerPosition + Vector3.down, 1<<8)) // 1<<8 - Wall layer
            return false;
        playerMovement.Move(Vector3.down, "walkDown");
        return true;
    }

    public void Undo() {
        playerMovement.Move(Vector3.up, "walkUp");
    }
}