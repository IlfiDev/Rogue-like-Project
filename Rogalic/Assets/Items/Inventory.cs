using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int amountSlots = 3;
    [SerializeField] public List<Item> items = new List<Item>();

    public delegate void ItemsChanged();
    public ItemsChanged itemsChanged;


    //Отправляем список с предметами Илюхе
    public bool addItem(Item item)
    {
        if(items.Count < amountSlots)
        {

            items.Add(item);

            if(itemsChanged != null)
                itemsChanged.Invoke();

            return true;

        } else return false;
    }

    //Отправляем список с предметами Илюхе
    public bool removeItem(Item item)
    {
        items.Remove(item);

        if (itemsChanged != null)
            itemsChanged.Invoke();

        return true;
    }
}
