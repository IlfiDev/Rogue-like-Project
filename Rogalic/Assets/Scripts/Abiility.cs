using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Abiility : ScriptableObject
{
    public Sprite icon;
    public GameObject particles;
    public new string name;
    public float cooldownTime;
    public float activeTime;
    public float manaCost;
    public int radius;

    public virtual void Activate(GameObject user)
    { 

    }
}
