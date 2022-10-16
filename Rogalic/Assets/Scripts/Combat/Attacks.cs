using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IAttack{
    public void PrimaryAttack(float damageMultiplier, Vector3 target);
    public void SecondaryAttack(float damageMultiplier, Vector3 target);
}

public interface IReload{
    public void Reload();
}

public interface IKnockable{
	public void TakeKnockback(float power, Vector3 direction);
}
