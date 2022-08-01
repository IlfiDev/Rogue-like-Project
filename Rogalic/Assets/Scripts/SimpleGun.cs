using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : Gun, IAttack
{
    
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
				Debug.Log(shootDir);
                bullet.GetComponent<BulletBehaviour>().Setup( _damage * damageMultiplier, shootDir);
                bullets.Add(bullet);
            }
            
    
            
        
        }
    }
}
