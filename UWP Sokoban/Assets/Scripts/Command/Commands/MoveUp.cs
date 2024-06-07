using UnityEngine;

public class MoveUp : ICommand {
    private PlayerMovement playerMovement;
    private Vector3 playerPosition;
    public MoveUp(PlayerMovement playerMovement, Vector3 position) {
        this.playerMovement = playerMovement;
        playerPosition = position;
    }
    //TODO check if can move
    public bool Execute() {
        if (Physics2D.OverlapPoint(playerPosition + Vector3.up, 1<<8)) // 1<<8 - Wall layer
            return false;
        playerMovement.Move(Vector3.up, "walkUp");
        return true;
    }

    public void Undo() {
        playerMovement.Move(Vector3.down, "walkDown");
    }
}