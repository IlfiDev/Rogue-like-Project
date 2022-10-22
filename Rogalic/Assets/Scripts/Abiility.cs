using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abiility : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    public float manaCost;
    public int radius;

    public virtual void Activate(GameObject user)
    { 

    }
}
