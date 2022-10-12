using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : Gun, IAttack
{
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private GameObject _rayObject;
    private GameObject _rayInstance;
    void Update()
    {
		checkCooldown(); 
    }

    public void Attack(float damageMultiplier, Vector3 target){
        Ray ray = new Ray(shootingPoint.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100f, _layerMask, QueryTriggerInteraction.Ignore)){
            if(_rayInstance == null){

                _rayInstance = Instantiate(_rayObject);
            }

            
            _rayInstance.GetComponent<RayBehaviour1>().UpdateRay(Vector3.Distance(shootingPoint.position, hit.point), (hit.point + shootingPoint.position) / 2, shootingPoint);
        }
    }
}
