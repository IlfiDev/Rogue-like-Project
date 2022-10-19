using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runEnemyState : StateMachineBehaviour
{
    private Transform player_coordinates;
    private Transform enemy_coordinates;
    private Enemy enemy;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Run Enemy State");
       player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       enemy_coordinates = animator.GetComponent<Transform>();
       enemy = animator.GetComponent<Enemy>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(enemy_coordinates.position, player_coordinates.position);
        if(distance < enemy.ChaseRange) {
            animator.SetBool("PlayerClose", false);
        }

        RaycastHit hit;
        if(Physics.Linecast(enemy_coordinates.position, player_coordinates.position, out hit)) {
            if(hit.transform.tag == "Player") {
                animator.SetBool("PlayerDamageable", true);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
