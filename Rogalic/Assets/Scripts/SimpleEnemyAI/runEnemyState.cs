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
    private Ray[] _rayArr = new Ray[5]; 


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Run Enemy State");
        _player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _enemy_coordinates = animator.GetComponent<Transform>();
        _enemy = animator.GetComponent<Enemy>();
        _agent = animator.GetComponent<NavMeshAgent>();
        _attacker = animator.GetComponent<AttackerNew>();

        _weapon_point = _attacker.GetWeaponPoint();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(_enemy_coordinates.position, _player_coordinates.position);
        if (distance > _enemy.ChaseRange)
        {
            animator.SetBool("PlayerClose", false);
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

        createRayArray();
        foreach(Ray i in _rayArr) {
            if(Physics.Raycast(i, out RaycastHit hit)) {
                if(hit.transform.tag == "Player") {
                    _attacker.PrimaryAttack((_weapon_point.forward * 1.5f + _weapon_point.position));
                } else {
                     _agent.SetDestination(_player_coordinates.position);
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    private void createRayArray() {
        Vector3 weapon_forward = _weapon_point.forward;
        _rayArr[0] = new Ray(_weapon_point.position, weapon_forward);

        Vector3 vector1 = weapon_forward;
        vector1.x = vector1.x - 0.3f;
        vector1.z = vector1.z - 0.3f;
        _rayArr[1] = new Ray(_weapon_point.position, vector1);

        Vector3 vector2 = weapon_forward;
        vector2.x = vector2.x - 0.3f;
        vector2.z = vector2.z + 0.3f;
        _rayArr[2] = new Ray(_weapon_point.position, vector2);
        
        Vector3 vector3 = weapon_forward;
        vector3.x = vector3.x + 0.3f;
        vector3.z = vector3.z - 0.3f;
        _rayArr[3] = new Ray(_weapon_point.position, vector3);

        Vector3 vector4 = weapon_forward;
        vector4.x = vector4.x + 0.3f;
        vector4.z = vector4.z + 0.3f;
        _rayArr[4] = new Ray(_weapon_point.position,  vector4);
    }
}
