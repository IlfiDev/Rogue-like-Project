using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    [SerializeField] private Transform player_coordinates;

    private void Start()
    {
        player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player_coordinates.position, transform.position);
        if(distance <= radius)
        {
            Debug.Log("Interact");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
