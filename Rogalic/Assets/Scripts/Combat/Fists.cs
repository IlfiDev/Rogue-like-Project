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

	public void PrimaryAttack(float damageMultiplier, Vector3 target){
		if (canAttack){
			this.target = target;
			Transform shootingPoint = gameObject.GetComponent<Transform>();
			timeStamp = Time.time + CooldownTime;

			Collider[] hitEnemies = Physics.OverlapBox(target, new Vector3(radius, radius, radius), Quaternion.identity, layer);
			foreach(Collider enemy in hitEnemies){
				if(enemy.TryGetComponent(out IDamagable damagable)){
					damagable.TakeDamage(Damage * damageMultiplier);
				}
				if(enemy.TryGetComponent(out IKnockable knockable)){
					knockable.TakeKnockback(KnockbackPower, shootingPoint.forward);
				}
			}
		}
	}

	void OnDrawGizmosSelected(){

		Gizmos.DrawCube(target, new Vector3(radius * 2, radius * 2));
	}
}
