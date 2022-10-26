using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSword : MeleeWeapon
{
	private void Start(){
		timeStamp = Time.time;
	}
	private void Update(){
		checkCooldown();
	}
    
	public override void PrimaryAttack(float damageMultiplier, Vector3 target){
		if (canAttack){
			this.target = target;
		    Transform shootingPoint = gameObject.GetComponent<Transform>();

			timeStamp = Time.time + CooldownTime;

			Collider[] hitEnemies = Physics.OverlapSphere(target, radius, layer);

			foreach(Collider enemy in hitEnemies){

				if(enemy.TryGetComponent(out IDamagable damagable)){
					damagable.TakeDamage(Damage);
					
				}
				if(enemy.TryGetComponent(out IKnockable knockable)){
                    if(enemy.transform.tag == "Bullet"){
                        knockable.TakeKnockback(KnockbackPower, shootingPoint.forward);
                    }
					knockable.TakeKnockback(KnockbackPower, shootingPoint.forward);
				}
			}
		}
	}
	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(target, radius);
	}
}
