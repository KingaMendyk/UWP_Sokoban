using UnityEngine;

public class MoveUp : ICommand {
    private PlayerMovement playerMovement;
    public MoveUp(PlayerMovement playerMovement) {
        this.playerMovement = playerMovement;
    }
    //TODO check if can move
    public bool Execute() {
        playerMovement.Move(Vector3.up, "walkUp");
        return true;
    }

    public void Undo() {
        playerMovement.Move(Vector3.down, "walkDown");
    }
}