using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IAttack
{
	[Header("Attack properties")]
    public float CooldownTime = 0.3f;
    public float Scatter = 0;
    public int NumberOfAttacks = 1;
    public float StartupTime = 0;
    [SerializeField] protected string tag;
	 [Space(10)]

	[Header("Impact on target")]
    public float Damage = 10f;
    public float Knockback = 0.1f;

	 [Space(10)]

	[Header("Transforms")]
    [SerializeField] protected Transform shootingPoint;

	 [Space(10)]

    protected float timeStamp;
    protected bool canAttack = true;
	
	protected Vector3 target;
	public virtual void PrimaryAttack(float damageMultiplier, Vector3 target){
		return;
	}

    public virtual void SecondaryAttack(float damageMultiplier, Vector3 target){
        return;
    }

   protected void checkCooldown(){
		if(timeStamp <= Time.time){
			canAttack = true;
		}
		else{
			canAttack = false;
		}
   }
   public void SetTag(string tag){
        this.tag = tag;
   }

}
