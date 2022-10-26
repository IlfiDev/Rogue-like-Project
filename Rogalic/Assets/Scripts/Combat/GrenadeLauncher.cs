using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Gun, IAttack, IStopAttack
{
    

    [SerializeField] private float _maxCharge = 15f;
    private float _currentCharge = 0f;
    private bool isHolding = true;
    private Vector3 _target;
    void Update()
    {
        checkCooldown();
    }                                           
    
    public override void PrimaryAttack(float damageMultiplier, Vector3 target){
        
        _target = target;
        if(_currentCharge <= _maxCharge){
            _currentCharge += 0.1f;
            Debug.Log(_currentCharge);
        }
    }
    protected void Attack(float damageMultiplier, Vector3 target){
        Debug.Log(_target);
        shootingPoint = gameObject.GetComponent<Transform>();
        if(canAttack){  
            timeStamp = Time.time + CooldownTime;
            for(int i = 0; i < NumberOfAttacks; i++){
                GameObject grenade = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
                Vector3 shootDir = (target - shootingPoint.position).normalized + new Vector3 (Random.Range(-Scatter, Scatter), 0f, Random.Range(-Scatter, Scatter));
                grenade.GetComponent<BulletBehaviour>().Setup(Damage, shootDir, ProjectileSize, tag, _currentCharge);
            }
        }
        _currentCharge = 0f;

    }
    public void StopPrimaryAttack(){
        Attack(0f, _target);
    }
}
