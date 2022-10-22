using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chillEnemyState : StateMachineBehaviour
{
    public float ChillTimer = 5f;
    private float _timer = 0;

    private Transform _player_coordinates;
    private Transform _enemy_coordinates;
    private Enemy _enemy;
    private Transform[] _enemyPoints;
    private NavMeshAgent _agent;
    private Vector3 _spawn_position;

    private bool _check_position = false;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Chill enemy state");
        _enemy = animator.GetComponent<Enemy>();
        _player_coordinates = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _enemy_coordinates = animator.GetComponent<Transform>();
        _agent = animator.GetComponent<NavMeshAgent>();

        if(_enemy.EnemyPoints != null) {
            _enemyPoints = _enemy.EnemyPoints.GetComponentsInChildren<Transform>();
        } else {
            _enemyPoints = null;
        }
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(_enemy_coordinates.position, _player_coordinates.position);
        if (distance < _enemy.AngerRadius)
        {
            animator.SetBool("PlayerClose", true);
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
        } else if(_enemyPoints != null && (!_agent.hasPath) ) {
            _agent.SetDestination(_enemyPoints[Random.Range(0, _enemyPoints.Length)].position);
            _check_position = false;
        }

        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
