using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    public Slider healthBar;
    public playerStatus player;

    public float curHealth=3;
    public float showHealth;

    public void ChngHealth(float num)
    {
        curHealth += player.currentHealth;
        if (curHealth > player.maxHealth)
        {
            curHealth = player.maxHealth;
        }
        else if(curHealth<0)
        {
            curHealth = 0;
        }

        
    }

    public void checkHealth()
    {
        
        if(curHealth!=showHealth)
        {
            float diff = (curHealth - showHealth)/100;

            if (diff > 0.00005f||diff<-0.00005f)
            {
                showHealth += diff;
            }
            else
            {
                showHealth = curHealth;
            }

        }

        if(healthBar!=null)
        {
            healthBar.value = showHealth/player.maxHealth;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        showHealth = curHealth;
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
    }
}
