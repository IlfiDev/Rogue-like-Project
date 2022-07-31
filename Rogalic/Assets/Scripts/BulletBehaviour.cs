using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Vector3 shootDir;
    
    public float moveSpeed = 100f;
    [SerializeField] private float _size = 1f; 
    public float _damage = 20;


    private void Start(){
        // Physics.IgnoreLayerCollision(0, 7);
        // Physics.IgnoreLayerCollision(7, 7);
    }

    public void Setup(float damage, Vector3 shootDir){
        transform.localScale = new Vector3(_size, _size, _size);
        this.shootDir = shootDir;
        this._damage = damage;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(shootDir * moveSpeed, ForceMode.Impulse);
        Destroy(gameObject, 1.5f);
    }

    // public void Update(){
        
    //     transform.position += shootDir * moveSpeed * Time.deltaTime;
    // }
    void OnTriggerEnter(Collider other){
        Debug.Log("Collision");
        if(other.tag != "Bullet"){
            if(other.TryGetComponent(out IDamagable damagable)){
            damagable.TakeDamage(_damage);
            
        }
        Debug.Log(other.transform.name);
        Destroy(gameObject);
        }
        
    }
}
