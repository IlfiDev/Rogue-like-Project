using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int ID;
    public string Name;
    public string Tag;
    public int maxHealth;
    public int currentHealth;
    public int maxMana;
    public int currentMana;
    public int damage;
    public int chaseSpeed;
    public int moveSpeed;
    public int attackRange;
    public int attackSpeed;
    public int chaseRange;
    
    //audio sources
    public AudioSource death_sound;

    //UI
    public HealthBar healthBar;
    public ManaBar manaBar;

    //Other
    public WaitForSeconds waitForSeconds;



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

    //Team
    public string GetTag()
    {
        return this.Tag;
    }
    public void SetTag(string Tag)
    {
        this.Tag = Tag;
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

    //maxMana
    public int GetMaxMana()
    {
        return this.maxMana;
    }
    public void SetMaxMana(int maxMana)
    {
        this.maxMana = maxMana;
    }

    //currentMana
    public int GetCurrentMana()
    {
        return this.currentMana;
    }
    public void SetCurrentMana(int currentMana)
    {
        this.currentMana = currentMana;
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
        this.SetTag(gameObject.tag);
        
        if (this.Tag == "Player")
        {
            StartCoroutine(passive_regeneratin());

        }
        if (this.Tag == "Enemy")
        {

        }
    }

    void Update()
    {
        
    }

    public void onSpawn()
    {

    }

    public void onDeath()
    {

    }

    public void TakeDamage(int damage)
    {
        this.currentHealth -= damage;
    }

    public void Attack()
    {

    }

    public void HealHealth(int heal)
    {
        if (this.currentHealth + heal >= this.maxHealth)
        {
            this.currentHealth = this.maxHealth;
        }
        else
        {
            this.currentHealth += heal;
        }
    }

    public void HealMana(int heal)
    {
        if (this.currentMana + heal >= this.maxMana)
        {
            this.currentMana = this.maxMana;
        }
        else
        {
            this.currentMana += heal;
        }
    }

    public void UseMana(int mana)
    {
        if (this.currentMana - mana >= 0)
            this.currentMana -= mana;
    }

    //Coroutines
    IEnumerator passive_regeneratin()
    {
        while (true)
        {
            this.HealHealth(1);
            this.HealMana(1);
            yield return new WaitForSeconds(1);
        }
    }
}
