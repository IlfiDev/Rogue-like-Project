using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform ParentOfSlots;
    private Inventory inventory;
    private Attacker attacker;
    private NewGameController newGameController;

    InventorySlot[] slots;
    int what_slot_active = 0;
    Player player;

    void Start()
    {
        attacker = GameObject.FindGameObjectWithTag("Player").GetComponent<Attacker>();
        inventory = attacker.GetComponent<Inventory>();
        player = inventory.GetComponent<Player>();

        inventory.itemsChanged += UpdateUI;

        slots = ParentOfSlots.GetComponentsInChildren<InventorySlot>();
        slots[what_slot_active].SlotButtonPress();

        newGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<NewGameController>();
        
    }

    private void FixedUpdate()
    {
        if (what_slot_active != 0)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                slots[0].SlotButtonPress();
                slots[what_slot_active].SlotButtonUnPressed();
                what_slot_active = 0;
                attacker.SwitchWeapon(0);
            }
        }


        if (what_slot_active != 1)
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                slots[1].SlotButtonPress();
                slots[what_slot_active].SlotButtonUnPressed();
                what_slot_active = 1;
                attacker.SwitchWeapon(1);
            }
        }


        if (what_slot_active != 2)
        {
            if (Input.GetKey(KeyCode.Alpha3))
            {
                slots[2].SlotButtonPress();
                slots[what_slot_active].SlotButtonUnPressed();
                what_slot_active = 2;
                attacker.SwitchWeapon(2);
            }
        }

        if (Input.GetKey(KeyCode.F) && slots[what_slot_active].item != null)
        {
            //Call the method in Player Script, that will drop the item on the ground

            inventory.removeItem(slots[what_slot_active].item);

            //newGameController.SpawnChest();

            Debug.Log("Fuck");
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f) 
        {
            slots[what_slot_active].SlotButtonUnPressed();

            if (what_slot_active < (slots.Length-1))
            {
                what_slot_active++;
            } else
            {
                what_slot_active = 0;
            }

            slots[what_slot_active].SlotButtonPress();
            attacker.SwitchWeapon(what_slot_active);
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            slots[what_slot_active].SlotButtonUnPressed();

            if(what_slot_active > 0)
            {
                what_slot_active--;
            } else
            {
                what_slot_active = slots.Length-1;
            }

            slots[what_slot_active].SlotButtonPress();
            attacker.SwitchWeapon(what_slot_active);
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } else
            {
                slots[i].RemoveItem();
            }
        }
    }

    public void SlotButtonPressed(string str)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].name == str)
            {
                slots[i].SlotButtonPress();
                attacker.SwitchWeapon(i);
                slots[what_slot_active].SlotButtonUnPressed();
                what_slot_active = i;
                return;
            }
        }
    }
}
