using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chaseBehaviour : StateMachineBehaviour
{
    EnemyUnit enemy;
    NavMeshAgent agent;
    Transform player;
    float attackRange;
    float chaseRange;
    int chaseSpeed;
    int moveSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = animator.GetComponent<EnemyUnit>();
        attackRange = enemy.GetAttackRange();
        chaseRange = enemy.GetChaseRange();
        chaseSpeed = enemy.GetChaseSpeed();
        moveSpeed = enemy.GetMoveSpeed();
        agent.speed = chaseSpeed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < attackRange)
            animator.SetBool("isAttacking", true);
        if (distance > chaseRange * 1.5)
            animator.SetBool("isChasing", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = moveSpeed;
    }
}
