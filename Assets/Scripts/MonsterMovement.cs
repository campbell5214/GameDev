using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    private int patrolDestination;
    public bool isAttacking = false;

    void Update()
    {
        if (isAttacking)
        {
            // Stop moving while attacking
            return;
        }

        PatrolBetweenPoints();
    }

    private void PatrolBetweenPoints()
    {
        // Move towards the current patrol point
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDestination].position, moveSpeed * Time.deltaTime);

        // Check if the patrol point is reached
        if (Vector2.Distance(transform.position, patrolPoints[patrolDestination].position) < 1f)
        {
            // Switch to the next patrol point
            patrolDestination = (patrolDestination + 1) % patrolPoints.Length;
        }
    }

    public void StartAttacking()
    {
        isAttacking = true;
    }

    public void StopAttacking()
    {
        isAttacking = false;
    }
}
