using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int maxMana = 100;
    public int currentMana = 0;
    public int level = 0;
    public float speed = 10;



    public Transform player_coordinates;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public WaitForSeconds waitForSeconds;

    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        player_coordinates = GameObject.Find("Player").transform;
        StartCoroutine(passive_regeneratin());
    }

    void Update()
    {
        
        healthBar.SetHealth(currentHealth);
        manaBar.SetMana(currentMana);

        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(20);
            UseMana(30);
        }
        if (currentHealth <= 0)
        {
            onDeath();
        }
        if (player_coordinates.position.y < -100)
        {
            onDeath();
        }
    }


    // player methods
    IEnumerator passive_regeneratin()
    {
        while (true)
        {
            if (currentHealth < maxHealth)
            {
                currentHealth++;
            }
            if (currentMana < maxMana)
            {
                currentMana++;
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void UseMana(int mana_cost)
    {
        if (currentMana - mana_cost >= 0)
        {
            currentMana -= mana_cost;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    void onDeath()
    {
        Vector3 vector = new Vector3(0f, 1f, 0f);
        player_coordinates.position = vector;
        Physics.SyncTransforms();
        currentHealth = maxHealth;
        currentMana = maxMana;
    }
}