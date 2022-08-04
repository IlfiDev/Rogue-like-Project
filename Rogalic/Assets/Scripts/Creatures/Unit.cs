using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour 
{
    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected float currentHealth = 100;
    [SerializeField] protected float maxMana = 200;
    [SerializeField] protected float currentMana = 200;
    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected float Gravity = -9.81f;

    public void setMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public void setCurrentHealth(float newCurrentHealth)
    {
        currentHealth = newCurrentHealth;
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }
    
    public void setMaxMana(float newMaxMana)
    {
        maxMana = newMaxMana;
    }

    public float getMaxMana()
    {
        return maxMana;
    }

    public void setCurrentMana(float newCurrentMana)
    {
        currentMana = newCurrentMana;
    }

    public float getCurrentMana()
    {
        return currentMana;
    }

    public void setMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public float getGravity()
    {
        return Gravity;
    }
}
