using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit, IDamagable, IKnockable
{

    private EnemyHealthBar _healthBar;
    [SerializeField] private CharacterController _characterController;
    private AttackerNew _attacker;
    private WeaponSwitcher _switcher;
    [SerializeField] private GameObject _defaultWeapon;

    public float AngerRadius = 15f;
    public float ChaseRange = 15f;
    
    private void Awake(){
        _attacker = gameObject.AddComponent<AttackerNew>();
        _switcher = gameObject.AddComponent<WeaponSwitcher>();
    }
    private void Start()
    {
        
        _switcher.SetDefaultWeapon(_defaultWeapon);
        _switcher.SetAttacker(_attacker);
        _switcher.InitWeapons();
        _healthBar = gameObject.GetComponentInChildren<EnemyHealthBar>();
        _healthBar.SetMaxHealth(getMaxHealth());

        _characterController = gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        EnemyMovements();
        if(impact.magnitude > 0.2){
            _characterController.Move(impact * Time.deltaTime);
        }
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
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

            _healthBar.SetHealth(temp_health);
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
        if (_characterController.isGrounded)
        {
            gravity.y = -2f;
        }
        else
        {
            gravity.y -= getGravity() * -4f * Time.deltaTime;
        }
        _characterController.Move(gravity);
    }
	public void TakeKnockback(float power, Vector3 direction){
        impact += direction * power / mass;
	}
}
