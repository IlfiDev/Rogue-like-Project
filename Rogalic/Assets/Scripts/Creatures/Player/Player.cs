using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit, IDamagable
{
    PlayerMovement playerMovement;
    HealthBar healthBar;
    ManaBar manaBar;
    private MeshRenderer blinkRadius = null;

    private void Start()
    {
        playerMovement = gameObject.AddComponent<PlayerMovement>();
        Inventory inventory = gameObject.AddComponent<Inventory>();

        healthBar = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(getMaxHealth());

        manaBar = GameObject.FindGameObjectWithTag("Mana bar").GetComponent<ManaBar>();
        manaBar.SetMaxMana(getMaxMana());

        MeshRenderer[] meshObjects = gameObject.GetComponentsInChildren<MeshRenderer>();
        
        foreach (MeshRenderer meshRenderer in meshObjects)
        {
            if (meshRenderer.name == "Cylinder")
            {
                blinkRadius = meshRenderer;
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetpoint = ray.GetPoint(hitdist);
                blink(targetpoint);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            blinkRadius.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            blinkRadius.enabled = false;
        }
        if (gameObject.transform.position.y < -50f)
        {
            Death();
        }
    }

    public void ManaDamage(int mana_damge)
    {
        setCurrentMana(getCurrentMana() - mana_damge);
        manaBar.SetMana(getCurrentMana());
    }

    private void Death()
    {
        Debug.Log("you died");

        float temp_max_health = getMaxHealth();
        setCurrentHealth(temp_max_health);
        healthBar.SetHealth(temp_max_health);

        float temp_max_mana = getMaxMana();
        setCurrentMana(temp_max_mana);
        manaBar.SetMana(temp_max_mana);

        NewGameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<NewGameController>();
        gameController.RespawnPlayer();
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

    private void blink(Vector3 targetPosition)
    {
        if(Vector3.Distance(gameObject.transform.position, targetPosition) < 20f)
        {
            gameObject.transform.position = targetPosition;
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, 20f);
        }
    }
}
