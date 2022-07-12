using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Vector3 shootDir;
    
    public float moveSpeed = 100f;  
    public int damage = 20;
    public void Setup(Vector3 shootDir){
        this.shootDir = shootDir;
        //Пофиксить поворот снарядов
        Destroy(this, 5f);
    }

    public void Update(){
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision other){
        Debug.Log("Collision");
        if(other.collider.TryGetComponent(out IDamagable damagable)){
            damagable.TakeDamage(damage);
        }
    }
}
