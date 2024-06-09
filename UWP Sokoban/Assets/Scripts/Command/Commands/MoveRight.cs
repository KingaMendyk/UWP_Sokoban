using UnityEngine;

public class MoveRight : ICommand {
    private PlayerMovement playerMovement;
    private Vector3 playerPosition;

    private int crateLayer = 1 << 6;
    private int wallLayer = 1 << 8;
    private int groundLayer = 1 << 9;
    
    public MoveRight(PlayerMovement playerMovement, Vector3 position) {
        this.playerMovement = playerMovement;
        playerPosition = position;
    }
    public bool Execute() {
        Vector2 destination = playerPosition + Vector3.right;
        
        if (Physics2D.OverlapPoint(destination, wallLayer)) {
            return false;
        }
        
        Collider2D collider = Physics2D.OverlapPoint((destination), crateLayer);
        if (collider) {
            if (Physics2D.OverlapPoint(playerPosition + 2 * Vector3.right, wallLayer) || 
                !Physics2D.OverlapPoint(playerPosition + 2 * Vector3.right, groundLayer)) {
                return false;
            }
            playerMovement.Move(Vector3.right, "walkRight", collider.gameObject);
            return true;
        }
        
        if (Physics2D.OverlapPoint(destination, groundLayer)) { 
            playerMovement.Move(Vector3.right, "walkRight");
            return true;
        }
        return false;
    }

    public void Undo() {
        playerMovement.Move(Vector3.left, "walkLeft");
    }
}