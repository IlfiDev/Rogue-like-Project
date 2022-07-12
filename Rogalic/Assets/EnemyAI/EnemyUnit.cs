using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public int ID;
    public string Name;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public int chaseSpeed;
    public int moveSpeed;
    public int attackRange;
    public int attackSpeed;
    public int chaseRange;

    // ID
    public int GetID()
    {
        return this.ID;
    }
    public void SetID(int ID)
    {
        this.ID = ID;
    }

    //Name
    public string GetName()
    {
        return this.Name;
    }
    public void SetName(string Name)
    {
        this.Name = Name;
    }

    //maxHealth
    public int GetMaxHealth()
    {
        return this.maxHealth;
    }
    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    //currentHealth
    public int GetCurrentHealth()
    {
        return this.currentHealth;
    }
    public void SetCurrentHealth(int currentHealth)
    {
        this.currentHealth = currentHealth;
    }

    //damage
    public int GetDamage()
    {
        return this.damage;
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    //moveSpeed
    public int GetMoveSpeed()
    {
        return this.moveSpeed;
    }
    public void SetMoveSpeed(int moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    //chaseSpeed
    public int GetChaseSpeed()
    {
        return this.chaseSpeed;
    }
    public void SetChaseSpeed(int chaseSpeed)
    {
        this.chaseSpeed = chaseSpeed;
    }

    //attackRange
    public int GetAttackRange()
    {
        return this.attackRange;
    }
    public void SetAttackRange(int attackRange)
    {
        this.attackRange = attackRange;
    }

    //attackSpeed
    public int GetAttackSpeed()
    {
        return this.attackSpeed;
    }
    public void SetAttackSpeed(int attackSpeed)
    {
        this.attackSpeed = attackSpeed;
    }

    //chaseRange
    public int GetChaseRange()
    {
        return this.chaseRange;
    }
    public void SetChaseRange(int chaseRange)
    {
        this.chaseRange = chaseRange;
    }

    // MainPart
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
