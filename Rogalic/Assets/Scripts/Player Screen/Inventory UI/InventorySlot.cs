using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject item;
    public Image icon;
    public Button itemButton;

    public InventoryUI inventoryUI;

    public void AddItem(GameObject newItem, Sprite item_icon)
    {
        //Debug.Log("You add item");

        item = newItem;
        icon.sprite = item_icon;
        icon.enabled = true;

    }

    public void RemoveItem()
    {
        //Debug.Log("You remove item");
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void SlotButtonPress()
    {
        itemButton.GetComponent<Image>().color = itemButton.colors.pressedColor;
        //Debug.Log("You press slot buttton");

        //If item != null, display 3d object on the scene
        
    }

    public void SlotButtonUnPressed()
    {
        itemButton.GetComponent<Image>().color = itemButton.colors.normalColor;
    }

    public void SlotButtonPressedByMouse()
    {
        inventoryUI.SlotButtonPressed(this.name);
    }

}
