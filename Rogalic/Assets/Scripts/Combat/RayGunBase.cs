using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunBase : MonoBehaviour
{
  [SerializeField] protected float rayWidth = 0.1f;
  [SerializeField] protected GameObject ray;
  [SerializeField] protected float scatter = 1f;
  [SerializeField] protected Transform shootingPoint;
  [SerializeField] protected int numberOfShots = 1;
  [SerializeField] protected float knockback;
  [SerializeField] protected float startupTime = 0;
  protected bool canAttack = true;
  protected List<GameObject> rays = new List<GameObject>();
  protected float timeStamp;
  [SerializeField] protected float cooldownTime = 1f; 

  protected void checkCooldown(){
		if(timeStamp <= Time.time){
			canAttack = true;
		}
		else{
			canAttack = false;
		}
   }
}
