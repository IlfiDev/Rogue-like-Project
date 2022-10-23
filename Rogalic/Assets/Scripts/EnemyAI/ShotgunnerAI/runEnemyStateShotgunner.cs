using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class runEnemyStateShotgunner : StateMachineBehaviour
{
    private Transform _player_coordinates = null;
    private Transform _enemy_coordinates;
    private Enemy _enemy;
    private NavMeshAgent _agent;
    private AttackerNew _attacker;

    private Transform _weapon_point;
    private Ray[] _gunRayArr = new Ray[5]; 


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
        
      /*  
        Ray ray = new Ray(_weapon_point.position, _weapon_point.forward);
        if (Physics.Raycast(ray, out RaycastHit hit2)) {
            if(hit2.transform.tag == "Player") {
                Debug.Log("Yes");
                _attacker.PrimaryAttack((_weapon_point.forward * 1.5f + _weapon_point.position));
            }
        }
        */

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
        _gunRayArr[0] = new Ray(_weapon_point.position, weapon_forward);

        Vector3 vector1 = weapon_forward;
        vector1.x = vector1.x - 0.3f;
        vector1.z = vector1.z - 0.3f;
        _gunRayArr[1] = new Ray(_weapon_point.position, vector1);

        Vector3 vector2 = weapon_forward;
        vector2.x = vector2.x - 0.3f;
        vector2.z = vector2.z + 0.3f;
        _gunRayArr[2] = new Ray(_weapon_point.position, vector2);
        
        Vector3 vector3 = weapon_forward;
        vector3.x = vector3.x + 0.3f;
        vector3.z = vector3.z - 0.3f;
        _gunRayArr[3] = new Ray(_weapon_point.position, vector3);

        Vector3 vector4 = weapon_forward;
        vector4.x = vector4.x + 0.3f;
        vector4.z = vector4.z + 0.3f;
        _gunRayArr[4] = new Ray(_weapon_point.position,  vector4);
    }

    private void Shooting() {
        createRayArray();
        RaycastHit hit;

        foreach(Ray i in _gunRayArr) {
            if(Physics.Raycast(i, out hit)) {
                if(hit.transform.tag == "Player") {
                    _attacker.PrimaryAttack((_weapon_point.forward * 1.5f + _weapon_point.position));
                }
            }
        }
    }
}
