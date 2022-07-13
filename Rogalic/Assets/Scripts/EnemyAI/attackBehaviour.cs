using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class attackBehaviour : StateMachineBehaviour
{
    Unit enemy;
    NavMeshAgent agent;
    Transform player;

    float timer;
    int attackRange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = animator.GetComponent<Unit>();
        attackRange = enemy.GetAttackRange();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       //animator.transform.LookAt(player);
       float distance = Vector3.Distance(animator.transform.position, player.position);
       if (distance > attackRange)
           animator.SetBool("isAttacking", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
