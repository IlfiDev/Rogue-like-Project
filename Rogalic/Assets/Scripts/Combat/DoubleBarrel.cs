using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBarrel : Gun, IAttack
{
   

    void Update()
    {
        checkCooldown(); 
    }

    public void SecondaryAttack(float damageMultiplier, Vector3 target){
        if(currentAmountOfAmmo > 1){
            shootingPoint = gameObject.GetComponent<Transform>();
            if (canAttack){
            
                timeStamp = Time.time + CooldownTime;
		
                for(int i = 0; i < NumberOfAttacks * 2; i++){
                    GameObject bullet = Instantiate(projectile, shootingPoint.position,shootingPoint.rotation);
                    Vector3 shootDir = (target - shootingPoint.position).normalized + new Vector3 (Random.Range(-Scatter, Scatter), 0f, Random.Range(-Scatter, Scatter));
                    bullet.GetComponent<BulletBehaviour>().Setup(Damage * damageMultiplier, shootDir, ProjectileSize);
                    bullets.Add(bullet);
                }
                currentAmountOfAmmo -= 2;
		    }

        }
        else{
            StartCoroutine(Reload(reloadTime));
        }
    }
}
