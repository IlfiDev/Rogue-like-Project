using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class runEnemyStateGunDude : StateMachineBehaviour
{
    private Transform _player_coordinates = null;
    private Transform _enemy_coordinates;
    private Enemy _enemy;
    private NavMeshAgent _agent;
    private AttackerNew _attacker;

    private Transform _weapon_point;
    private Ray _gunRay;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Run Enemy State");
        GameObject temp_player = GameObject.FindGameObjectWithTag("Player");
        if(temp_player != null) {
            _player_coordinates = temp_player.GetComponent<Transform>();
        }

        _enemy_coordinates = animator.GetComponent<Transform>();
        _enemy = animator.GetComponent<Enemy>();
        _agent = animator.GetComponent<NavMeshAgent>();
        _attacker = animator.GetComponent<AttackerNew>();

        _agent.speed = _enemy.getMoveSpeed();
        _weapon_point = _attacker.GetWeaponPoint();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_player_coordinates == null) {
            GameObject temp_player = GameObject.FindGameObjectWithTag("Player");
            if(temp_player == null) return;

            _player_coordinates = temp_player.GetComponent<Transform>();
        }

        float distance = Vector3.Distance(_enemy_coordinates.position, _player_coordinates.position);
        if (distance > _enemy.ChaseRange)
        {
            _agent.isStopped = true;
            animator.SetBool("PlayerClose", false);
            return;
        }

        if(_agent.isStopped == true) _agent.isStopped = false;

        RaycastHit hit;
        if(Physics.Linecast(_enemy_coordinates.position, _player_coordinates.position, out hit)) {
            if(hit.transform.tag == "Player") {
                _agent.SetDestination(_enemy_coordinates.position);

                Vector3 lookDir = _player_coordinates.position - _enemy_coordinates.position;
                lookDir.y = 0f;
                Quaternion lookRotation = Quaternion.FromToRotation(_enemy_coordinates.forward, lookDir);
                _enemy_coordinates.rotation = Quaternion.RotateTowards(_enemy_coordinates.rotation, Quaternion.LookRotation(lookDir), Time.time * 0.5f);

                Shooting();
            } else {
                _agent.SetDestination(_player_coordinates.position);
            }
        } else {
            _agent.SetDestination(_player_coordinates.position);
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

    private void createRayArray() {
        Vector3 weapon_forward = _weapon_point.forward;
        _gunRay = new Ray(_weapon_point.position, weapon_forward);
    }

    private void Shooting() {
        createRayArray();
        RaycastHit hit;

        if(Physics.Raycast(_gunRay, out hit)) {
            if(hit.transform.tag == "Player") {
                _attacker.PrimaryAttack((_weapon_point.forward * 1.5f + _weapon_point.position));
            }
        }
    }
}
