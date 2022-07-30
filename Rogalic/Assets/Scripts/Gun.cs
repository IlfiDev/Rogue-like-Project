using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IAttack
{
    [SerializeField] protected float _cooldownTime = 0.3f;
    [SerializeField] protected GameObject _projectile;
    [SerializeField] protected float _damage = 10f;
    [SerializeField] protected Transform _shootingPoint;
    [SerializeField] protected float _timeStamp;
    [SerializeField] protected float _scatter;
    [SerializeField] protected int _numberOfShots;
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
    public void Attack(float damageMultiplier, Vector3 target){
        
        _shootingPoint = gameObject.GetComponent<Transform>();
        if (canShoot){
            
            _timeStamp = Time.time + _cooldownTime;
            for(int i = 0; i < _numberOfShots; i++){
                GameObject bullet = Instantiate(_projectile, _shootingPoint.position, _shootingPoint.rotation);
                Vector3 shootDir = (target - _shootingPoint.position).normalized + new Vector3 (Random.Range(-_scatter, _scatter), 0f, Random.Range(-_scatter, _scatter));
                bullet.GetComponent<BulletBehaviour>().Setup( _damage * damageMultiplier, shootDir);
                bullets.Add(bullet);
            }
            
    
            
        
        }
    }

}
