using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour, IKnockable
{
    protected Vector3 shootDir;
    protected Renderer _renderer; 
    public float moveSpeed = 100f;
    [SerializeField] protected float _size = 1f; 
    public float _damage = 20;
    protected string _tag = "Player";
    protected Rigidbody rb;

    private void Start(){
        // Physics.IgnoreLayerCollision(0, 7);
        // Physics.IgnoreLayerCollision(7, 7);
		rb = transform.GetComponent<Rigidbody>();
    }

    public void Setup(float damage, Vector3 shootDir, float bulletSize, string tag){
        _tag = tag;
        transform.localScale = transform.localScale * bulletSize;
        if(_tag == "Enemy"){
            
            _renderer = transform.GetComponent<Renderer>();
            _renderer.material.SetColor("_Color", Color.red);
        }
        if(_tag == "Player"){
            _renderer = transform.GetComponent<Renderer>();
            _renderer.material.SetColor("_Color", Color.yellow);
        }
        this.shootDir = shootDir;
        this._damage = damage;
		rb = gameObject.GetComponent<Rigidbody>();
		
        rb.AddForce(shootDir * moveSpeed, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }

    public void Setup(float damage, Vector3 shootDir, float bulletSize, string tag, float speed){
        _tag = tag;
        transform.localScale = transform.localScale * bulletSize;
        if(_tag == "Enemy"){
            
            _renderer = transform.GetComponent<Renderer>();
            _renderer.material.SetColor("_Color", Color.red);
        }
        if(_tag == "Player"){
            _renderer = transform.GetComponent<Renderer>();
            _renderer.material.SetColor("_Color", Color.yellow);
        }
        this.shootDir = shootDir;
        this._damage = damage;
		rb = gameObject.GetComponent<Rigidbody>();
		
        rb.AddForce(shootDir * speed, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }
    // public void Update(){
        
    //     transform.position += shootDir * moveSpeed * Time.deltaTime;
    // }
    void OnTriggerEnter(Collider other){
        if(other.tag != "Bullet" && other.tag != "FloorTrigger"){
            if(other.TryGetComponent(out IDamagable damagable)){
                if(other.tag != _tag){
                    
                    damagable.TakeDamage(_damage);
                    Destroy(gameObject);
                }
            
            }
            else{
                Destroy(gameObject);
            }
        }
        
    }
	public void TakeKnockback(float power, Vector3 direction){
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero; 
		rb.AddForce( direction * moveSpeed , ForceMode.Impulse);
	}
}
