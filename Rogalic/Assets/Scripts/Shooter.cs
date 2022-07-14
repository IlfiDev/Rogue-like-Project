using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject target;
    private Vector3 targetVector;
    private void Start(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    

    private void Update(){
        
        
        if(Input.GetButton("Fire1")){
            if (target == null){
                targetVector = shootingPoint.position + shootingPoint.forward;
                Shoot(targetVector);
            }else{
                targetVector = target.transform.position;
                Shoot(targetVector);
            }
            
        }
    }

    public void Shoot(Vector3 target){
        GameObject bullet = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);

        Vector3 shootDir = (target - shootingPoint.position).normalized;
        bullet.GetComponent<BulletBehaviour>().Setup(shootDir);
    }
}
