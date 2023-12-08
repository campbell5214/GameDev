using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public int coin = 0;
    public HealthBar health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Heart"))
        {
            health.ChngHealth(collision.collider.gameObject.GetComponent<Item>().change);
        }
        else if(collision.collider.gameObject.CompareTag("Coin"))
        {
            health.ChngHealth(collision.collider.gameObject.GetComponent<Item>().change);
            coin++;
        }
    }
}
