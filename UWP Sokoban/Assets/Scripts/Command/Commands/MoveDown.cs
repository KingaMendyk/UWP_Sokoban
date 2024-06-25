using UnityEngine;

public class MoveDown : ICommand{
    private PlayerMovement playerMovement;
    private Vector3 playerPosition;
    private bool withCrate;
    private GameObject crate;
    
    private int crateLayer = 1 << 6;
    private int wallLayer = 1 << 8;
    private int groundLayer = 1 << 9;
    
    public MoveDown(PlayerMovement playerMovement, Vector3 position) {
        this.playerMovement = playerMovement;
        playerPosition = position;
    }
    public bool Execute() {
        Vector2 destination = playerPosition + Vector3.down;
        
        if (Physics2D.OverlapPoint(destination, wallLayer)) {
            return false;
        }
        
        Collider2D collider = Physics2D.OverlapPoint((destination), crateLayer);
        if (collider) {
            if (Physics2D.OverlapPoint(playerPosition + 2 * Vector3.down, wallLayer) || 
                Physics2D.OverlapPoint(playerPosition + 2 * Vector3.down, crateLayer) || 
                !Physics2D.OverlapPoint(playerPosition + 2 * Vector3.down, groundLayer)) {
                return false;
            }

            withCrate = true;
            crate = collider.gameObject;
            playerMovement.Move(Vector3.down, "walkDown", crate);
            return true;
        }
        
        if (Physics2D.OverlapPoint(destination, groundLayer)) { 
            playerMovement.Move(Vector3.down, "walkDown");
            return true;
        }
        return false;
    }

    public void Undo() {
        if(withCrate)
            playerMovement.Move(Vector3.up, "walkUp", crate);
        playerMovement.Move(Vector3.up, "walkUp");
    }
}