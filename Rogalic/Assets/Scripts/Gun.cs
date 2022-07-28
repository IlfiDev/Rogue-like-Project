using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IAttack
{
    [SerializeField] private float _cooldownTime = 0.3f;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private float _timeStamp;
    public bool canShoot = true;
    private List<GameObject> bullets = new List<GameObject>();
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
    public void Attack(float damageMultiplier, Vector3 target){
        
        _shootingPoint = gameObject.GetComponent<Transform>();
        Debug.Log(_shootingPoint.position);
        if (canShoot){
            
            _timeStamp = Time.time + _cooldownTime;
           
            GameObject bullet = Instantiate(_projectile, _shootingPoint.position, _shootingPoint.rotation);
            Vector3 shootDir = (target - _shootingPoint.position).normalized;
            bullet.GetComponent<BulletBehaviour>().Setup( _damage * damageMultiplier, shootDir);
            bullets.Add(bullet);
            
    
            
        
        }
    }

}
