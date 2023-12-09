using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float shootTime;
    private float shootCounter;

    void Start()
    {
        shootCounter = shootTime;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shootCounter <= 0)
        {
            ShootProjectileTowardsMouse();
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;

    }

    private void ShootProjectileTowardsMouse()
    {
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)launchPoint.position).normalized;

        // Set the rotation of the projectile to face the mouse cursor
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Set the velocity of the projectile
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectile.GetComponent<ProjectileBehaviour>().speed;

        // Debugging: Draw a line in the Scene view for visualizing the direction
        Debug.DrawLine(launchPoint.position, mousePosition, Color.red, 2f);

        Debug.Log("Mouse Position in World Coordinates: " + mousePosition);
    }
}