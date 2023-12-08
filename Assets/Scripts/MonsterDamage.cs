using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{

    public int damage;
    public PlayerHealth playerHealth;
    public playerController PlayerController;

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
    }
}
