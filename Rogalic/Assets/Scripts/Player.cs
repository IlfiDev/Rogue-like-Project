using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    PlayerMovement playerMovement;
    HealthBar healthBar;
    ManaBar manaBar;

    private void Start()
    {
        playerMovement = new PlayerMovement(gameObject);

        healthBar = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(getMaxHealth());

        manaBar = GameObject.FindGameObjectWithTag("Mana bar").GetComponent<ManaBar>();
        manaBar.SetMaxMana(getMaxMana());
    }

    void FixedUpdate()
    {
        playerMovement.ShitMoveVersion();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            HealthDamage(20);
        }

    }

    public void HealthDamage(int health_damage)
    {
        setCurrentHealth(getCurrentHealth() - health_damage);
        healthBar.SetHealth(getCurrentHealth());
    }

    public void ManaDamage(int mana_damge)
    {
        setCurrentMana(getCurrentMana() - mana_damge);
        manaBar.SetMana(getCurrentMana());
    }
}
