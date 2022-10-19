using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chillEnemyState : StateMachineBehaviour
{
    private Transform player_coordinates;
    private Transform enemy_coordinates;
    private Enemy enemy;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy_coordinates = animator.GetComponent<Transform>();
        
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(enemy_coordinates.position, player_coordinates.position) <= enemy.AngerRadius) {
            animator.SetBool("PlayerClose", true);
        }
        Debug.Log("Chill enemy state");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
