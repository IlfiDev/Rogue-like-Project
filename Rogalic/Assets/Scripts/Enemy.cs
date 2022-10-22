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
    private Transform _player_coordinates;

    public GameObject EnemyPoints = null;

    public float AngerRadius = 25f;
    public float ChaseRange = 25f;
    public Vector3? Bykanut;
    
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
        _player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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

            Bykanut = _player_coordinates.position;
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

    private void DrawRay() {
        Vector3 something3 = _attacker.GetWeaponPoint().forward * ChaseRange;
        Debug.DrawRay(_attacker.GetWeaponPoint().position, something3, Color.green);

        Vector3 something21 = _attacker.GetWeaponPoint().forward * 10f;
        something21.x = something21.x - 0.3f;
        something21.z = something21.z - 0.3f;

        Debug.DrawLine(_attacker.GetWeaponPoint().position, _attacker.GetWeaponPoint().position + something21, Color.green);

        Vector3 something22 = _attacker.GetWeaponPoint().forward * 10f;
        something22.x = something22.x - 0.3f;
        something22.z = something22.z + 0.3f;

        Debug.DrawLine(_attacker.GetWeaponPoint().position, _attacker.GetWeaponPoint().position + something22, Color.green);

        Vector3 something23 = _attacker.GetWeaponPoint().forward * 10f;
        something23.x = something23.x + 0.3f;
        something23.z = something23.z - 0.3f;

        Debug.DrawLine(_attacker.GetWeaponPoint().position, _attacker.GetWeaponPoint().position + something23, Color.green);

        Vector3 something24 = _attacker.GetWeaponPoint().forward * 10f;
        something24.x = something24.x + 0.3f;
        something24.z = something24.z + 0.3f;

        Debug.DrawLine(_attacker.GetWeaponPoint().position, _attacker.GetWeaponPoint().position + something24, Color.green);
    }
}
