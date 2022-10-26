using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectShotgun : Gun, IAttack
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkCooldown(); 
    }
    
    public override void PrimaryAttack(float damageMultiplier, Vector3 target){
        shootingPoint = gameObject.GetComponent<Transform>();
        if(canAttack){
            timeStamp = Time.time + CooldownTime;
            for(int i = 0; i < NumberOfAttacks; i++){
                GameObject bullet = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
                Vector3 shootDir =  Quaternion.Euler(0, 0, i * 180/ NumberOfAttacks + transform.rotation.z) * transform.forward; 
                bullet.GetComponent<BulletBehaviour>().Setup(Damage * damageMultiplier, shootDir, ProjectileSize, tag, 0);
                bullets.Add(bullet);
            }
        }
    }
}
