using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : MeleeWeapon, IAttack
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
		checkCooldown();
    }

	public void Attack(float damageMultiplier, Vector3 target){
		if (canAttack){
			_target = target;
			Transform shootingPoint = gameObject.GetComponent<Transform>();
			_timeStamp = Time.time + _cooldownTime;

			Collider[] hitEnemies = Physics.OverlapBox(target, new Vector3(_radius, _radius, _radius), Quaternion.identity, _layer);
			foreach(Collider enemy in hitEnemies){
				if(enemy.TryGetComponent(out IDamagable damagable)){
					damagable.TakeDamage(_damage * damageMultiplier);
				}
				if(enemy.TryGetComponent(out IKnockable knockable)){
					knockable.TakeKnockback(_knockbackPower, shootingPoint.position);
				}
			}
		}
	}

	void OnDrawGizmosSelected(){

		Gizmos.DrawCube(_target, new Vector3(_radius * 2, _radius * 2, _radius * 2));
	}
}
