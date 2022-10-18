using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovements : MonoBehaviour
{

    private Transform player_coordinates;

    private NavMeshAgent agent;
    private float radius = 20f;
    
    void Start()
    {
        player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if(Vector3.Distance(player_coordinates.position, transform.position) <= radius) {
            agent.SetDestination(player_coordinates.position);
        }
    }
}
