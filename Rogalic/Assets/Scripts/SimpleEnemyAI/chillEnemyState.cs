using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chillEnemyState : StateMachineBehaviour
{
    public float ChillTimer = 5f;
    private float timer = 0;

    private Transform player_coordinates;
    private Transform enemy_coordinates;
    private Enemy enemy;
    private Transform[] enemyPoints;
    private NavMeshAgent agent;
    private Vector3 spawn_position;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Chill enemy state");
        enemy = animator.GetComponent<Enemy>();
        player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy_coordinates = animator.GetComponent<Transform>();
        agent = animator.GetComponent<NavMeshAgent>();

        if(enemy.EnemyPoints != null) {
            enemyPoints = enemy.EnemyPoints.GetComponentsInChildren<Transform>();
        } else {
            enemyPoints = null;
        }
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(enemy_coordinates.position, player_coordinates.position);
        if (distance < enemy.AngerRadius)
        {
            animator.SetBool("PlayerClose", true);
        }

        if(enemyPoints != null && (!agent.hasPath) ) {
            agent.SetDestination(enemyPoints[Random.Range(0, enemyPoints.Length)].position);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
