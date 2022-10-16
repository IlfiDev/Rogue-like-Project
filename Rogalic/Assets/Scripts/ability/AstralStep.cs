using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "AstralStepAbility", menuName = "AbilityHolder/AstralStep")]

public class AstralStep : Abiility
{
    public override void Activate(GameObject user)
    {
        Plane playerPlane = new Plane(Vector3.up, user.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetpoint = ray.GetPoint(hitdist);
            Step(targetpoint, user);
        }
    }
    private void Step(Vector3 targetPosition, GameObject user)
    {
        AbilityCoroutineController gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityCoroutineController>();
        if (Vector3.Distance(user.transform.position, targetPosition) < 30f)
        {
            gameController.astralStepTargerPoint = targetPosition;
            gameController.astralStepUser = user;
        }
        else
        {
            gameController.astralStepTargerPoint = Vector3.MoveTowards(user.transform.position, targetPosition, 30f);
            gameController.astralStepUser = user;
        }
    }
}