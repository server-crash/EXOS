using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth=100;
    public int currentHealth;
    public HealthBarManager healthBar;
    void Start()
    {
        currentHealth=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame

    public void TakeDamage(int damage)
    {
        currentHealth-=damage;
        healthBar.SetHealth(currentHealth);

    }
    public void HealthPowerup()
    {
        currentHealth=maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}
