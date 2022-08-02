using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
	[SerializeField] private Attacker attacker;

	private void Start(){
		attacker = transform.GetComponent<Attacker>();
	}

	public void SwitchWeapon(int index){
		return;
	}
}
