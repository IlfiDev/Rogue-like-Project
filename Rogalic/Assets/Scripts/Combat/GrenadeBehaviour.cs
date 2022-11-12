using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : BulletBehaviour, IKnockable
{
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        if(other.tag != "Bullet" && other.tag != "FloorTrigger"){
            gameObject.GetComponent<Explosive>().Explode(); 
        }

    }
}
