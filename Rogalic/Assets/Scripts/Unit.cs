using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int currentHealth = 100;
    [SerializeField] protected int maxMana = 200;
    [SerializeField] protected int currentMana = 200;
    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected float Gravity = -9.81f;

    public void setMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void setCurrentHealth(int newCurrentHealth)
    {
        currentHealth = newCurrentHealth;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }
    
    public void setMaxMana(int newMaxMana)
    {
        maxMana = newMaxMana;
    }

    public int getMaxMana()
    {
        return maxMana;
    }

    public void setCurrentMana(int newCurrentMana)
    {
        currentMana = newCurrentMana;
    }

    public int getCurrentMana()
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
