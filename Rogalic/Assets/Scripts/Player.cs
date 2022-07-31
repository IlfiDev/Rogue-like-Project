using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit, IDamagable
{
    PlayerMovement playerMovement;
    HealthBar healthBar;
    ManaBar manaBar;

    private void Start()
    {
        playerMovement = gameObject.AddComponent<PlayerMovement>();
        Inventory inventory = gameObject.AddComponent<Inventory>();

        healthBar = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(getMaxHealth());

        manaBar = GameObject.FindGameObjectWithTag("Mana bar").GetComponent<ManaBar>();
        manaBar.SetMaxMana(getMaxMana());
    }

    void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

    }

    public void ManaDamage(int mana_damge)
    {
        setCurrentMana(getCurrentMana() - mana_damge);
        manaBar.SetMana(getCurrentMana());
    }

    private void Death()
    {
        Debug.Log("you died");

        float temp_max_health = getMaxHealth();
        setCurrentHealth(temp_max_health);
        healthBar.SetHealth(temp_max_health);

        float temp_max_mana = getMaxMana();
        setCurrentMana(temp_max_mana);
        manaBar.SetMana(temp_max_mana);

        NewGameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<NewGameController>();
        //gameController.RespawnPlayer();
    }

    public void TakeDamage(float damage)
    {
        float temp_health = getCurrentHealth() - damage;

        if (temp_health <= 0)
        {
            Death();
        }
        else
        {
            setCurrentHealth(temp_health);
            healthBar.SetHealth(temp_health);
        }
    }
}
