using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class attackBehaviour : StateMachineBehaviour
{
    EnemyUnit enemy;
    NavMeshAgent agent;
    Transform player;
    Player target;
    float timer;
    int damage;
    int attackRange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = animator.GetComponent<EnemyUnit>();
        damage = enemy.GetDamage();
        attackRange = enemy.GetAttackRange();
        target.TakeDamage(damage);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.transform.LookAt(player);
       float distance = Vector3.Distance(animator.transform.position, player.position);
       if (distance > attackRange)
           animator.SetBool("isAttacking", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
