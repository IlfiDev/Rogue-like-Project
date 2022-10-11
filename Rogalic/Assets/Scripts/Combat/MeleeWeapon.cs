using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : Weapon
{
	[Header("Melee Attack Properties")]
   [SerializeField] protected float radius = 1f;
   public GameObject AttackArea;
   public bool CanDeflectProjectiles = false;
   public bool CanDestroyProjectiles = false;
   public float KnockbackPower;
   [Space(10)]
   [SerializeField] protected LayerMask layer;
   protected void checkCooldown(){
		if(timeStamp <= Time.time){
			canAttack = true;
		}
		else{
			canAttack = false;
		}
   }
}
