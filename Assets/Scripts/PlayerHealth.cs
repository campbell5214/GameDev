using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    private Vector3 respawnPoint;
    private Vector3 initialPosition;

    public ProgressBar healthBar; // Reference to the health bar

    void Start()
    {
        health = maxHealth;
        initialPosition = transform.position;
        respawnPoint = initialPosition;

        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Respawn();
        }
        UpdateHealthBar();
    }

    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    public void Respawn()
    {
        health = maxHealth; // Reset health
        transform.position = respawnPoint; // Move player to respawn point

        // Update health bar
        if (healthBar != null)
        {
            healthBar.BarValue = health * 10; // Reset health bar value
        }
    }

    public void RespawnAtInitialPosition()
    {
        health = maxHealth; // Reset health
        transform.position = initialPosition; // Move player to initial position

        // Update health bar
        if (healthBar != null)
        {
            healthBar.BarValue = health * 10; // Reset health bar value
        }
    }

    public bool HasCheckpoint()
    {
        // Check if a checkpoint has been set
        return respawnPoint != initialPosition;
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.BarValue = (float)health / maxHealth * 100; // Scale the health value to the ProgressBar's scale
        }
    }
}
