using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Vector3 shootDir;
    
    public float moveSpeed = 100f;  
    public float _damage = 20;


    private void Start(){
        Physics.IgnoreLayerCollision(0, 7);
        Physics.IgnoreLayerCollision(7, 7);
    }

    public void Setup(float damage, Vector3 shootDir){
        
        this.shootDir = shootDir;
        this._damage = damage;
        //Пофиксить поворот снарядов
        Destroy(gameObject, 1.5f);
    }

    public void Update(){
        
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision other){
        Debug.Log("Collision");
        if(other.transform.TryGetComponent(out IDamagable damagable)){
            damagable.TakeDamage(_damage);
            
        }
        Debug.Log(other.transform.name);
        Destroy(gameObject);
    }
}
