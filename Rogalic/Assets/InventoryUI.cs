using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform ParentOfSlots;
    private Inventory inventory;
    private GameController gameController;

    InventorySlot[] slots;
    int what_slot_active = 0;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.itemsChanged += UpdateUI;

        slots = ParentOfSlots.GetComponentsInChildren<InventorySlot>();
        slots[what_slot_active].SlotButtonPress();

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
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
            }
        }


        if (what_slot_active != 1)
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                slots[1].SlotButtonPress();
                slots[what_slot_active].SlotButtonUnPressed();
                what_slot_active = 1;
            }
        }


        if (what_slot_active != 2)
        {
            if (Input.GetKey(KeyCode.Alpha3))
            {
                slots[2].SlotButtonPress();
                slots[what_slot_active].SlotButtonUnPressed();
                what_slot_active = 2;
            }
        }

        if (Input.GetKey(KeyCode.F) && slots[what_slot_active].item != null)
        {
            inventory.removeItem(slots[what_slot_active].item);
            gameController.SpawnChest();

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
                slots[what_slot_active].SlotButtonUnPressed();
                what_slot_active = i;
            }
        }
    }

    private void MouseWheelMovements()
    {

    }
}
