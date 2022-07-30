using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun, IAttack
{
    
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
                Vector3 shootDir = ((target - _shootingPoint.position) + new Vector3 (Random.Range(-_scatter, _scatter), 0f, Random.Range(-_scatter, _scatter))).normalized;
                bullet.GetComponent<BulletBehaviour>().Setup( _damage * damageMultiplier, shootDir);
                bullets.Add(bullet);
            }
            
            
    
            
        
        }
    }
}
