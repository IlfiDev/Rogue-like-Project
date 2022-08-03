using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSword : MeleeWeapon, IAttack
{
		private void Start(){
		_timeStamp = Time.time;
	}
	private void Update(){
		checkCooldown();
	}
    
	public void Attack(float damageMultiplier, Vector3 target){
		if (canAttack){
			_target = target;
		    Transform shootingPoint = gameObject.GetComponent<Transform>();

			_timeStamp = Time.time + _cooldownTime;

			Collider[] hitEnemies = Physics.OverlapSphere(target, _radius, _layer);

			foreach(Collider enemy in hitEnemies){

				if(enemy.TryGetComponent(out IDamagable damagable)){
					Debug.Log("Took Damage");
					damagable.TakeDamage(_damage);
					
				}
				if(enemy.TryGetComponent(out IKnockable knockable)){
						knockable.TakeKnockback(_knockbackPower, shootingPoint.position);
					}
			}
		}
	}
	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(_target, _radius);
	}
}
