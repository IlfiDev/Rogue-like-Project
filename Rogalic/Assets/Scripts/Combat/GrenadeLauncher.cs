using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Gun, IAttack, IStopAttack
{
    

    [SerializeField] private float _maxCharge = 15f;
    [SerializeField] private float _maxRadius = 15f;
    private float _currentCharge = 0f;
    private bool isHolding = true;
    private Vector3 _target;
    private Animator _anim;
    private void Start(){
        _anim = GetComponentInChildren<Animator>();
        _anim.enabled = false;
    }
    void Update()
    {
        checkCooldown();
    }                                           
    
    public override void PrimaryAttack(float damageMultiplier, Vector3 target){
       if(canAttack){
           _anim.enabled = true;
           _anim.Play("WeaponShaking");
            _target = target;
            if(_currentCharge <= _maxCharge){
                _currentCharge += 0.1f;
                _anim.speed = _currentCharge / _maxCharge;
                Debug.Log(_currentCharge);
            }
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
                grenade.GetComponent<BulletBehaviour>().Setup(Damage, shootDir, ProjectileSize, tag, _maxRadius * (_currentCharge / _maxCharge));
            }
        }
        _currentCharge = 0f;

    }
    public void StopPrimaryAttack(){
        Attack(0f, _target);
        _anim.enabled = false;
    }
}
