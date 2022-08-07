using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour, IKnockable
{
    private Vector3 shootDir;
    
    public float moveSpeed = 100f;
    [SerializeField] private float _size = 1f; 
    public float _damage = 20;

    private Rigidbody rb;

    private void Start(){
        // Physics.IgnoreLayerCollision(0, 7);
        // Physics.IgnoreLayerCollision(7, 7);
		rb = transform.GetComponent<Rigidbody>();
    }

    public void Setup(float damage, Vector3 shootDir, float bulletSize){
        transform.localScale = transform.localScale * bulletSize;
        this.shootDir = shootDir;
		Debug.Log(shootDir);
		Debug.Log(moveSpeed);
        this._damage = damage;
		rb = gameObject.GetComponent<Rigidbody>();
		if (rb == null){
			Debug.Log("Cock");
		}
		
        rb.AddForce(shootDir * moveSpeed, ForceMode.Impulse);
        Destroy(gameObject, 1.5f);
    }

    // public void Update(){
        
    //     transform.position += shootDir * moveSpeed * Time.deltaTime;
    // }
    void OnTriggerEnter(Collider other){
        if(other.tag != "Bullet" && other.tag != "FloorTrigger"){
            if(other.TryGetComponent(out IDamagable damagable)){
            damagable.TakeDamage(_damage);
            
        }
        Destroy(gameObject);
        }
        
    }
	public void TakeKnockback(float power, Vector3 direction){
		rb.AddForce((transform.position - direction).normalized * power * moveSpeed, ForceMode.Impulse);
	}
}
