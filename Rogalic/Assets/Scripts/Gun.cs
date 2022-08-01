using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Gun : MonoBehaviour
{
    [SerializeField] protected float _cooldownTime = 0.3f;
    [SerializeField] protected GameObject _projectile;
    [SerializeField] protected float _damage = 10f;
    [SerializeField] protected Transform _shootingPoint;
    [SerializeField] protected float _timeStamp;
    [SerializeField] protected float _scatter;
    [SerializeField] protected int _numberOfShots;
    [SerializeField] protected float _knockback = 0.1f;
    [SerializeField] protected float _startupTime = 0;
    protected bool canShoot = true;
    protected List<GameObject> bullets = new List<GameObject>();
    private void Start(){
        _timeStamp = Time.time;
        _shootingPoint = gameObject.GetComponent<Transform>();
    }

    private void Update(){
        
        if (_timeStamp <= Time.time){
            canShoot = true;
        }
        else{
            canShoot = false;
        }
    }
    

}
