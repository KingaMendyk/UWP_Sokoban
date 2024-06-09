using UnityEngine;

public class MoveLeft : ICommand {
    private PlayerMovement playerMovement;
    private Vector3 playerPosition;
    
    private int crateLayer = 1 << 6;
    private int wallLayer = 1 << 8;
    private int groundLayer = 1 << 9;
    
    public MoveLeft(PlayerMovement playerMovement, Vector3 position) {
        this.playerMovement = playerMovement;
        playerPosition = position;
    }
    public bool Execute() {
        Vector2 destination = playerPosition + Vector3.left;
        
        if (Physics2D.OverlapPoint(destination, wallLayer)) {
            return false;
        }
        
        Collider2D collider = Physics2D.OverlapPoint((destination), crateLayer);
        if (collider) {
            if (Physics2D.OverlapPoint(playerPosition + 2 * Vector3.left, wallLayer) || 
                !Physics2D.OverlapPoint(playerPosition + 2 * Vector3.left, groundLayer)) {
                return false;
            }
            playerMovement.Move(Vector3.left, "walkLeft", collider.gameObject);
            return true;
        }
        
        if (Physics2D.OverlapPoint(destination, groundLayer)) { 
            playerMovement.Move(Vector3.left, "walkLeft");
            return true;
        }
        return false;
    }

    public void Undo() {
        playerMovement.Move(Vector3.right, "walkRight");
    }
}