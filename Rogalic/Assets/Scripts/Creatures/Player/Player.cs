using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Unit, IDamagable
{
    private PlayerMovement playerMovement;
    private HealthBar healthBar;
    private ManaBar manaBar;
    private MeshRenderer blinkRadius = null;
    private AttackerNew _attacker;
    private WeaponSwitcher _switcher;
    private AbilityCoroutineController _abilityCoroutineController;

    [SerializeField] private GameObject _defaultWeapon;

    private GameObject gameController;

    public bool isDead = false;
    public bool canBeRespawned = false;


    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        Inventory inventory = gameObject.AddComponent<Inventory>();
        _attacker = gameObject.AddComponent<AttackerNew>();
        _abilityCoroutineController = gameObject.AddComponent<AbilityCoroutineController>();
        _switcher = gameObject.AddComponent<WeaponSwitcher>();
        _attacker.SetAsPlayer();
    }

    private void Start()
    {
        _switcher.SetDefaultWeapon(_defaultWeapon);
        _switcher.SetAttacker(_attacker);
        _switcher.InitWeapons();
        playerMovement = gameObject.AddComponent<PlayerMovement>();

        healthBar = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(getMaxHealth());

        manaBar = GameObject.FindGameObjectWithTag("Mana bar").GetComponent<ManaBar>();
        manaBar.SetMaxMana(getMaxMana());

        StartCoroutine(regeneration());
        StartCoroutine(manaRegeneration());
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);
        manaBar.SetMana(currentMana);

        if (gameObject.transform.position.y < -50f && canBeRespawned == false)
        {
            Death();
        }
    }

    void FixedUpdate()
    {
        if (canBeRespawned == true)
        {
            respawn();
        }
    }

    public void ManaDamage(int mana_damge)
    {
        setCurrentMana(getCurrentMana() - mana_damge);
        manaBar.SetMana(getCurrentMana());
    }

    private void Death()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        isDead = true;
        healthBar.SetHealth(currentHealth);
        foreach(MeshRenderer obj in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            obj.enabled = false;
        }
    }

    public void TakeDamage(float damage)
    {
        float temp_health = getCurrentHealth() - damage;

        if (temp_health <= 0)
        {
            setCurrentHealth(temp_health);
            Death();
        }
        else
        {
            setCurrentHealth(temp_health);
        }
    }

    public bool UseMana(float value)
    {
        float temp_mana = getCurrentMana() - value;

        if (temp_mana <= 0)
        {
            return false;
        }
        else
        {
            setCurrentMana(temp_mana);
            return true;
        }
    }

    public void respawn()
    {
        Vector3 spawnPosition = GameObject.FindGameObjectWithTag("PlayerSpawnPoint").transform.position;
        gameObject.transform.position = spawnPosition;

        canBeRespawned = false;

        foreach (MeshRenderer obj in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            obj.enabled = true;
        }

        setCurrentHealth(maxHealth);
        setCurrentMana(maxMana);

        gameObject.GetComponent<PlayerMovement>().enabled = true;

        StartCoroutine(regeneration());
        StartCoroutine(manaRegeneration());
    }

    IEnumerator regeneration()
    {
        while(true)
        {
            yield return new WaitForEndOfFrame();
            if (currentHealth < maxHealth)
            {
                heal(5f * Time.deltaTime);
            }
        }
    }

    IEnumerator manaRegeneration()
    {
        while(true)
        {
            yield return new WaitForEndOfFrame();
            if (currentMana < maxMana)
            {
                healMana(10f * Time.deltaTime);
            }
        }
    }
}
