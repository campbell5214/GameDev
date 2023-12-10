using UnityEngine;

public class Killbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming there is a PlayerHealth script attached to the player GameObject
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Check if the player has a checkpoint set
            if (playerHealth != null && playerHealth.HasCheckpoint())
            {
                // Respawn the player at the last checkpoint
                playerHealth.Respawn();
            }
            else
            {
                // If no checkpoint is set, respawn at the initial position (you can customize this behavior)
                playerHealth.RespawnAtInitialPosition();
            }
        }
    }
}

