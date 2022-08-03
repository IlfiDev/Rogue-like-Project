using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : MonoBehaviour
{
   [SerializeField] protected float _damage;
   [SerializeField] protected float _cooldownTime = 0.3f;
   [SerializeField] protected float _radius = 1f;
   protected float _timeStamp;
   protected bool canAttack = true;
   [SerializeField] protected GameObject attackArea;
   [SerializeField] protected bool canDeflectProjectiles = false;
   [SerializeField] protected bool canDestroyProjectiles = false;
   [SerializeField] protected LayerMask _layer;
   [SerializeField] protected float _knockbackPower = 1f;
	protected Vector3 _target;

   protected void checkCooldown(){
		if(_timeStamp <= Time.time){
			canAttack = true;
		}
		else{
			canAttack = false;
		}
   }
}
