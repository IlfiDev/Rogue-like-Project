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
        if (target == null){
            targetVector = Input.mousePosition;
        }else{
            targetVector = target.transform.position;
        }
    }
    

    private void Update(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (target == null){
            targetVector = Input.mousePosition;
        }else{
            targetVector = target.transform.position;
        }
        if(Input.GetButton("Fire1")){
            Shoot(targetVector );
        }
    }

    public void Shoot(Vector3 dir){
        GameObject bullet = Instantiate(projectile, shootingPoint.position, Quaternion.identity);

        Vector3 shootDir = ( dir - shootingPoint.position).normalized;
        bullet.GetComponent<BulletBehaviour>().Setup(shootDir);
    }
}
