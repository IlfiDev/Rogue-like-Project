using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int amountSlots = 3;
    [SerializeField] public List<GameObject> items = new List<GameObject>();
    [SerializeField] public List<Sprite> icons = new List<Sprite>();

    public delegate void ItemsChanged();
    public ItemsChanged itemsChanged;

    Attacker attacker;

    private void Start()
    {
        attacker = GameObject.FindGameObjectWithTag("Player").GetComponent<Attacker>();
    }

    public bool addItem(GameObject item, Sprite icon)
    {
        if(items.Count < amountSlots)
        {

            items.Add(item);
            icons.Add(icon);
            attacker.UpdateWeapon(items.IndexOf(item), item.gameObject);

            if(itemsChanged != null)
                itemsChanged.Invoke();



            return true;

        } else return false;
    }

    public bool removeItem(GameObject item, Sprite icon)
    {
        
        attacker.UpdateWeapon(items.IndexOf(item), null);
        
        item.GetComponent<Interactible>().enabled = true;

        icons.Remove(icon);
        items.Remove(item);

        if (itemsChanged != null)
            itemsChanged.Invoke();

        return true;
    }
}
