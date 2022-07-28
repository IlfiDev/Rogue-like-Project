using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit, IDamagable
{

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
        }
    }

    public void ManaDamage(int mana_damge)
    {
        setCurrentMana(getCurrentMana() - mana_damge);
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
