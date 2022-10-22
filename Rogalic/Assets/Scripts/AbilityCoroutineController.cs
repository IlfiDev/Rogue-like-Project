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
        user.GetComponent<AbilityHolder>().enabled = false;
        user.GetComponent<BoxCollider>().isTrigger = true;
        user.GetComponent<BoxCollider>().size = new Vector3(3,1,3);
        while (Vector3.Distance(user.transform.position, targetPoint) > 0.1f)
        {
            user.transform.position = Vector3.Lerp(user.transform.position, targetPoint, 15f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        user.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
        user.GetComponent<BoxCollider>().isTrigger = false;
        user.GetComponent<PlayerMovement>().enabled = true;
        user.GetComponent<AbilityHolder>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name != gameObject.name)
        {
            if (other.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(80f);
            }
        }
    }
}
