using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IAttack{
    public void Attack(float damageMultiplier, Vector3 target);
}

public interface IReload{
    public void Reload();
}