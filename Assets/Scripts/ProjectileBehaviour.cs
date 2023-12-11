using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed =50f;
    public Rigidbody2D projectileRb;
    public float projectileLife;
    public float projectileCount;
    public int damage;
    public Camera cam;
   
    Vector2 mousePos;
    Vector2 direction;

    void Start()
    {
        cam = Camera.main;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        direction = ShootAngle();
        direction.Normalize();
        projectileCount = projectileLife;
        projectileRb.velocity = direction * speed;
    }

    private void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*private void FixedUpdate()
    {
        projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
    }
   */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WeakPoint"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log("Damage dealt");
            }
            else
            {
                Debug.LogWarning("EnemyHealth component not found on collided object");
            }
            Destroy(gameObject);
        }
        Debug.Log("Projectile collided");
    }

        public Vector2 ShootAngle()
    {
        Vector2 shootDir = mousePos - projectileRb.position;
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg - 90f;
        return shootDir;
    }
}