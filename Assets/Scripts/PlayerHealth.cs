using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    private Vector3 respawnPoint;

    public ProgressBar healthBar; // Reference to the health bar
    public RespawnText respawnText; // Reference to the RespawnText script

    void Start()
    {
        health = maxHealth;
        respawnPoint = transform.position;

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

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.BarValue = (float)health / maxHealth * 100; // Scale the health value to the ProgressBar's scale
        }
    }

    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;

        // Show "Respawned" text
        if (respawnText != null)
        {
            respawnText.ShowRespawnText();
        }
    }

    private void Respawn()
    {
        health = maxHealth; // Reset health
        transform.position = respawnPoint; // Move player to respawn point

        // Update health bar
        if (healthBar != null)
        {
            healthBar.BarValue = health * 10; // Reset health bar value
        }
    }
}
