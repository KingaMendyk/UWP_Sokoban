using UnityEngine;

public class MoveDown : ICommand{
    private PlayerMovement playerMovement;
    public MoveDown(PlayerMovement playerMovement) {
        this.playerMovement = playerMovement;
    }
    public bool Execute() {
        playerMovement.Move(Vector3.down, "walkDown");
        return true;
    }

    public void Undo() {
        playerMovement.Move(Vector3.up, "walkUp");
    }
}