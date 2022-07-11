using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Transform player_coordinates;
    public HealthBar healthBar;
    public WaitForSeconds waitForSeconds;

    void Start()
    {
        currentHealth = maxHealth;
        player_coordinates = GameObject.Find("Player").transform;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(20);
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void onDeath()
    {
        Vector3 vector = new Vector3(0f, 1f, 0f);
        player_coordinates.position = vector;
        Physics.SyncTransforms();
        currentHealth = 100;
        healthBar.SetHealth(currentHealth);
    }
}