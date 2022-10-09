using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    [SerializeField] private Transform player_coordinates;

    [SerializeField] private GameObject item;
    [SerializeField] private Sprite icon;

    [SerializeField] private GameObject tooltip;

    private GameObject temp_tooltip;
    private Itemtooltip itemtooltip;
    private bool showBool = false;

    private void Start()
    {
        player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        item = gameObject;

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        Quaternion spawnRotation = Quaternion.identity;

        temp_tooltip = Instantiate(tooltip, spawnPosition, spawnRotation);
        temp_tooltip.transform.SetParent(transform);

        itemtooltip = temp_tooltip.GetComponentInChildren<Itemtooltip>();
        //itemtooltip.Show();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(player_coordinates.position, transform.position);
        if (distance <= radius)
        {
            if(!showBool)
            {
                showBool = true;
                itemtooltip.Show();
            }
   
            if(Input.GetKey(KeyCode.E))
            {
                PickUp();
            }
        } else
        {
            if (showBool)
            {
                showBool = false;
                itemtooltip.Hide();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void PickUp()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        bool isPickedUp = inventory.addItem(item, icon);

        if(isPickedUp)
        {
            itemtooltip.Hide();
            GetComponent<Interactible>().enabled = false;
        }
    }
}
