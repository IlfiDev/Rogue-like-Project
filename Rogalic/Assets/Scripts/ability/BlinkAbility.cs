using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "BlinkAbility", menuName = "AbilityHolder/blink")]
public class BlinkAbility : Abiility
{
    public override void Activate(GameObject user)
    {
        Plane playerPlane = new Plane(Vector3.up, user.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetpoint = ray.GetPoint(hitdist);
            GameObject explosion = Instantiate(particles, user.transform.position, user.transform.rotation);
            blink(targetpoint, user);
        }
    }
    private void blink(Vector3 targetPosition, GameObject user)
    {
        if (Vector3.Distance(user.transform.position, targetPosition) < (float)radius)
        {
            user.transform.position = targetPosition;
            GameObject explosion = Instantiate(particles, user.transform.position, user.transform.rotation);
        }
        else
        {
            user.transform.position = Vector3.MoveTowards(user.transform.position, targetPosition, (float)radius);
            GameObject explosion = Instantiate(particles, user.transform.position, user.transform.rotation);
        }
    }
}

