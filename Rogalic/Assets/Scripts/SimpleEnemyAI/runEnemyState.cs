using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class runEnemyState : StateMachineBehaviour
{
    private Transform _player_coordinates;
    private Transform _enemy_coordinates;
    private Enemy _enemy;
    private NavMeshAgent _agent;
    private AttackerNew _attacker;

    private Transform _weapon_point;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Run Enemy State");
        _player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _enemy_coordinates = animator.GetComponent<Transform>();
        _enemy = animator.GetComponent<Enemy>();
        _agent = animator.GetComponent<NavMeshAgent>();
        _attacker = animator.GetComponent<AttackerNew>();

        _weapon_point = _attacker._weaponPoint;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(_enemy_coordinates.position, _player_coordinates.position);
        if (distance > _enemy.ChaseRange)
        {
            animator.SetBool("PlayerClose", false);
        } else
        {
            _agent.SetDestination(_player_coordinates.position);
        }
        

        
        RaycastHit hit;
        Debug.DrawRay(_weapon_point.position, (_weapon_point.forward * (-1)), Color.green);
        if (Physics.Raycast(_weapon_point.position, (_weapon_point.forward * (-1)), out hit)) {
            if(hit.transform.tag == "Player") {
                Debug.Log("Yes");
                _attacker.PrimaryAttack((_weapon_point.forward * 1.5f + _weapon_point.position));
            }
        }


    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
