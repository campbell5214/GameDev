using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterDamage : MonoBehaviour
{

    public int damage;
    public PlayerHealth playerHealth;
    public playerController PlayerController;
    public int health = 100;
    public GameObject heartprefab;

    public UnityEvent onDead;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.KBCOunter = PlayerController.KBCTotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                PlayerController.KnockFromRIght = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                PlayerController.KnockFromRIght = false;
            }


            playerHealth.TakeDamage(damage);
        }
        //Monster Health
        if (collision.gameObject.CompareTag("Fireball"))
        {
            int damageAmount = collision.gameObject.GetComponent<ProjectileBehaviour>().damage;
            TakeDamageE(damageAmount);
        }
    }

    public void TakeDamageE(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle enemy death
        Destroy(gameObject);
        onDead.Invoke();
    }

    public void drop()
    {
        GameObject heart = Instantiate(heartprefab,transform,true);
    }

}
