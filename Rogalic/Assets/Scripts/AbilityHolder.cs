using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Abiility abiility_1;
    public Abiility abiility_2;
    public Abiility abiility_3;


    public KeyCode key_1;
    public KeyCode key_2;
    public KeyCode key_3;


    float cooldownTime_1;
    float cooldownTime_2;
    float cooldownTime_3;


    float activeTime_1;
    float activeTime_2;
    float activeTime_3;
    

    enum AbilityOneState { ready, active, onCooldown}
    enum AbilityTwoState { ready, active, onCooldown }
    enum AbilityThreeState { ready, active, onCooldown }


    AbilityOneState state_1 = AbilityOneState.ready;
    AbilityTwoState state_2 = AbilityTwoState.ready;
    AbilityThreeState state_3 = AbilityThreeState.ready;

    private MeshRenderer blinkRadius = null;

    private void Start()
    {
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
        //Ability Onr
        switch(state_1)
        {
            case AbilityOneState.ready:
                if(Input.GetKeyDown(key_1))
                {
                    abiility_1.Activate(gameObject);
                    state_1 = AbilityOneState.active;
                    activeTime_1 = abiility_1.activeTime;
                }
                break;
            case AbilityOneState.active:
                if(activeTime_1 > 0)
                {
                    activeTime_1 -= Time.deltaTime;
                }
                else
                {
                    state_1 = AbilityOneState.onCooldown;
                    cooldownTime_1 = abiility_1.cooldownTime;
                }
                break;
            case AbilityOneState.onCooldown:
                if (cooldownTime_1 > 0)
                {
                    cooldownTime_1 -= Time.deltaTime;
                }
                else
                {
                    state_1 = AbilityOneState.ready;
                }
                break;  
        }

        //Ability Two
        switch (state_2)
        {
            case AbilityTwoState.ready:
                if (Input.GetKeyDown(key_2))
                {
                    abiility_2.Activate(gameObject);
                    state_2 = AbilityTwoState.active;
                    activeTime_2 = abiility_1.activeTime;
                }
                break;
            case AbilityTwoState.active:
                if (activeTime_2 > 0)
                {
                    activeTime_2 -= Time.deltaTime;
                }
                else
                {
                    state_2 = AbilityTwoState.onCooldown;
                    cooldownTime_2 = abiility_2.cooldownTime;
                }
                break;
            case AbilityTwoState.onCooldown:
                if (cooldownTime_2 > 0)
                {
                    cooldownTime_2 -= Time.deltaTime;
                }
                else
                {
                    state_2 = AbilityTwoState.ready;
                }
                break;
        }

        //Ability Three
        switch (state_3)
        {
            case AbilityThreeState.ready:
                if (Input.GetKeyDown(key_3))
                {
                    abiility_3.Activate(gameObject);
                    state_3 = AbilityThreeState.active;
                    activeTime_2 = abiility_3.activeTime;
                }
                break;
            case AbilityThreeState.active:
                if (activeTime_3 > 0)
                {
                    activeTime_3 -= Time.deltaTime;
                }
                else
                {
                    state_3 = AbilityThreeState.onCooldown;
                    cooldownTime_3 = abiility_3.cooldownTime;
                }
                break;
            case AbilityThreeState.onCooldown:
                if (cooldownTime_3 > 0)
                {
                    cooldownTime_3 -= Time.deltaTime;
                }
                else
                {
                    state_3 = AbilityThreeState.ready;
                }
                break;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            blinkRadius.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            blinkRadius.enabled = false;
        }
    }
}
