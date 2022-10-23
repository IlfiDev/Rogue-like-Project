using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chillEnemyStateFastCreep : StateMachineBehaviour
{
    private Transform _player_coordinates = null;
    private Transform _enemy_coordinates;
    private Enemy _enemy;
    private Transform[] _enemyPoints;
    private NavMeshAgent _agent;
    private Vector3 _spawn_position;

    private bool _check_position = false;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Chill enemy state");
        GameObject temp_player = GameObject.FindGameObjectWithTag("Player");
        if(temp_player != null) {
            _player_coordinates = temp_player.GetComponent<Transform>();
        }

        _enemy = animator.GetComponent<Enemy>();
        _enemy_coordinates = animator.GetComponent<Transform>();
        _agent = animator.GetComponent<NavMeshAgent>();

        _agent.speed = _enemy.getMoveSpeed();
        if(_enemy.EnemyPoints != null) {
            _enemyPoints = _enemy.EnemyPoints.GetComponentsInChildren<Transform>();
        } else {
            _enemyPoints = null;
        }
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_player_coordinates == null) {
            GameObject temp_player = GameObject.FindGameObjectWithTag("Player");
            if(temp_player == null) return;

            _player_coordinates = temp_player.GetComponent<Transform>();
        }

        float distance = Vector3.Distance(_enemy_coordinates.position, _player_coordinates.position);
        if (distance < _enemy.AngerRadius)
        {
            animator.SetBool("PlayerClose", true);
            return;
        }

        if(_agent.isStopped == true) {
            _agent.isStopped = false;
            if(_enemyPoints != null) {
                _agent.SetDestination(_enemyPoints[Random.Range(0, _enemyPoints.Length)].position);
            } else {
                _agent.SetDestination(_enemy_coordinates.position);
            }
        } else if (_enemy.Bykanut != null) {
            _check_position = true;
            _agent.SetDestination((Vector3) _enemy.Bykanut);
            _enemy.Bykanut = null;
            Debug.Log("fuck");
        } else if(_enemyPoints != null && (!_agent.hasPath) ) {
            _agent.SetDestination(_enemyPoints[Random.Range(0, _enemyPoints.Length)].position);
            _check_position = false;
        }

        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
