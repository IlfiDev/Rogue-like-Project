
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Gun : Weapon, IAttack
{
	[SerializeField] protected GameObject projectile;
	public float ProjectileSize = 0.43f;
	protected List<GameObject> bullets = new List<GameObject>();
	private void Update(){

		checkCooldown();
		
	}
	public virtual void PrimaryAttack(float damageMultiplier, Vector3 target){
        shootingPoint = gameObject.GetComponent<Transform>();
        if (canAttack){
            
            timeStamp = Time.time + CooldownTime;
		
            for(int i = 0; i < NumberOfAttacks; i++){
                GameObject bullet = Instantiate(projectile, shootingPoint.position,shootingPoint.rotation);
                Vector3 shootDir = (target - shootingPoint.position).normalized + new Vector3 (Random.Range(-Scatter, Scatter), 0f, Random.Range(-Scatter, Scatter));
                bullet.GetComponent<BulletBehaviour>().Setup(Damage * damageMultiplier, shootDir, ProjectileSize, tag);
                bullets.Add(bullet);
            }
		}

	}
}
