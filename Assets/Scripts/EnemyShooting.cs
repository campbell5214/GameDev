using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float shootingRange = 20f; // Adjust as needed

    private MonsterMovement monsterMovement; // Reference to the MonsterMovement script
    private float timer;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        monsterMovement = GetComponent<MonsterMovement>(); // Initialize the monsterMovement variable
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < shootingRange)
        {
            timer += Time.deltaTime;

            if (timer > 2) // Adjust the shooting interval as needed
            {
                if (!monsterMovement.isAttacking)
                {
                    monsterMovement.StartAttacking(); // Start attacking
                }
                timer = 0;
                shoot();
            }
        }
        else
        {
            if (monsterMovement.isAttacking)
            {
                monsterMovement.StopAttacking(); // Stop attacking
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}