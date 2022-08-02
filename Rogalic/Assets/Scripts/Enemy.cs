using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit, IDamagable, IKnockable
{

    HealthBar healthBar;
    CharacterController characterController;

    private void Start()
    {
        healthBar = gameObject.GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(getMaxHealth());

        characterController = gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        EnemyMovements();
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

    public void ManaDamage(int mana_damge)
    {
        setCurrentMana(getCurrentMana() - mana_damge);
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void EnemyMovements()
    {
        Vector3 gravity = Vector3.zero;
        if (characterController.isGrounded)
        {
            gravity.y = -2f;
        }
        else
        {
            gravity.y -= getGravity() * -4f * Time.deltaTime;
        }
        characterController.Move(gravity);
    }
	public void TakeKnockback(float power, Vector3 direction){
		characterController.Move((transform.position - direction).normalized * power);
	}
}
