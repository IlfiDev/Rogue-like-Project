using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class runEnemyStateFastCreep : StateMachineBehaviour
{
    private Transform _player_coordinates;
    private Transform _enemy_coordinates;
    private Enemy _enemy;
    private NavMeshAgent _agent;
    private AttackerNew _attacker;

    private Transform _weapon_point;
    private float _meleeAttackRadius;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Run Enemy State");
        _player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _enemy_coordinates = animator.GetComponent<Transform>();
        _enemy = animator.GetComponent<Enemy>();
        _agent = animator.GetComponent<NavMeshAgent>();
        _attacker = animator.GetComponent<AttackerNew>();

        _meleeAttackRadius = _enemy.GetDefaultWeapon().GetComponent<Fists>().GetAttackRadius();
        _agent.speed = _enemy.getMoveSpeed();
        _weapon_point = _attacker.GetWeaponPoint();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_player_coordinates == null) return;

        float distance = Vector3.Distance(_enemy_coordinates.position, _player_coordinates.position);
        if (distance > _enemy.ChaseRange)
        {
            _agent.isStopped = true;
            animator.SetBool("PlayerClose", false);
            return;
        }


        if(distance > _meleeAttackRadius) {
            if(_agent.isStopped == true) _agent.isStopped = false;
            
            _agent.SetDestination(_player_coordinates.position);
        } else {
            Vector3 lookDir = _player_coordinates.position - _enemy_coordinates.position;
            lookDir.y = 0f;
            Quaternion lookRotation = Quaternion.FromToRotation(_enemy_coordinates.forward, lookDir);
            _enemy_coordinates.rotation = Quaternion.RotateTowards(_enemy_coordinates.rotation, Quaternion.LookRotation(lookDir), Time.time * 0.5f);

            Punching();
        }

/*
        createRayArray();
        foreach(Ray i in _rayArr) {
            if(Physics.Raycast(i, out hit)) {
                if(hit.transform.tag == "Player") {
                    _attacker.PrimaryAttack((_weapon_point.forward * 1.5f + _weapon_point.position));
                    _agent.SetDestination(_enemy.transform.position);
                } else {
                     _agent.SetDestination(_player_coordinates.position);
                }
            }
        }
        */
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    private void Punching() {
        Fists temp_fists = _enemy.GetDefaultWeapon().GetComponent<Fists>();

        if(temp_fists == null) return;

        float distance = Vector3.Distance(_enemy_coordinates.position, _player_coordinates.position);
        if(distance <= temp_fists.GetAttackRadius()) {
            _attacker.PrimaryAttack((_weapon_point.forward * 1.5f + _weapon_point.position));
        }
    }

}
