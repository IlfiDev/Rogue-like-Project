using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCoroutineController : MonoBehaviour
{
    public GameObject astralStepUser = null;
    public Vector3 astralStepTargerPoint = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        if (astralStepUser != null && astralStepTargerPoint != Vector3.zero)
        {
            StartCoroutine(AstralStep(astralStepTargerPoint, astralStepUser));
            astralStepUser = null;
            astralStepTargerPoint = Vector3.zero;
        }
    }
    IEnumerator AstralStep(Vector3 targetPoint, GameObject user)
    {
        user.GetComponent<PlayerMovement>().enabled = false;
        while (Vector3.Distance(user.transform.position, targetPoint) > 0.1f)
        {
            user.transform.position = Vector3.Lerp(user.transform.position, targetPoint, 10f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        user.GetComponent<PlayerMovement>().enabled = true;
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent(out IDamagable damagable))
    //    {
    //        damagable.TakeDamage(20f);
    //    }
    //}
}
