using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    [SerializeField] private Transform player_coordinates;
    [SerializeField] private Item item;

    private void Start()
    {
        player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(player_coordinates.position, transform.position);
        if (distance <= radius)
        {
            PickUp();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void PickUp()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        bool isPickedUp = inventory.addItem(item);

        if(isPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
