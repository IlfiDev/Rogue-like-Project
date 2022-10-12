using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBehaviour1 : MonoBehaviour
{
    [SerializeField]
    private float _damage = 1f;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateRay(float length, Vector3 middlePos, Transform rotation){
        transform.position = middlePos;
        transform.localScale = new Vector3(length, transform.localScale.y, transform.localScale.z);
        transform.rotation = rotation.rotation;
    }
    private void OnTriggerStay(Collider other){
        if(other.TryGetComponent(out IDamagable damagable)){
            damagable.TakeDamage(_damage);
        }
    }
}
