using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour, IDamagable, IKnockable
{
    [SerializeField] private GameObject _particles;
    [SerializeField] private float _power = 10f;
    [SerializeField] private float _damage = 50f;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _timeToExplosion = 1f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private LayerMask _layer;

    private void Start(){
        _rb = this.GetComponent<Rigidbody>();
    }
    private void Explode(){
        GameObject explosion = Instantiate(_particles, gameObject.transform.position, transform.rotation);
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, _radius, _layer);
        foreach(Collider enemy in hitEnemies){
            float distanceMultiplier = 1 - Vector3.Distance(transform.position, enemy.transform.position)/ _radius;
            if(enemy.TryGetComponent(out IDamagable damagable)){
                damagable.TakeDamage(_damage * distanceMultiplier);
            }
            if(enemy.TryGetComponent(out IKnockable knockable)){
                knockable.TakeKnockback(_power * distanceMultiplier, (enemy.transform.position - transform.position).normalized);
            }
        }
        explosion.transform.parent = null;
        Destroy(explosion, 1f);
        Destroy(gameObject);

    }
    public void TakeDamage(float damage){
        StartCoroutine(ExplosionTimer(_timeToExplosion));
    }
    public void TakeKnockback(float power, Vector3 direction){
        _rb.AddForce(direction * power, ForceMode.Impulse);
    }
    private IEnumerator ExplosionTimer(float time){
        yield return new WaitForSeconds(time);
        Explode();
    }
}
