using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _weaponPoint;
    private GameObject physicalWeapon;
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _currentWeapon;
    private Vector3 targetVector;
    [SerializeField] bool isPlayer = false;
	[SerializeField] private GameObject[] _weapons = new GameObject[3];
    private List<GameObject> _projectiles = new List<GameObject>();

    private void Start(){
		for(int i = 0; i < 3; i++){
			_weapons[i] = Instantiate(_weapons[i], _weaponPoint.position, _weaponPoint.rotation);
			_weapons[i].transform.parent = _weaponPoint.parent;
			_weapons[i].SetActive(false);
		}
		_currentWeapon = _weapons[0];
		_currentWeapon.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (!isPlayer){
            _target = GameObject.FindGameObjectWithTag("Player");
        }
    }
	public void GetWeapons(GameObject[] weapons){
		_weapons = weapons;
	}
	public void UpdateWeapon(int index, GameObject weapon){
		_weapons[index] = Instantiate(weapon, _weaponPoint.position, _weaponPoint.rotation);
	}
    public void SwitchWeapon(int index){
		foreach(GameObject weapon in _weapons){
			weapon.SetActive(false);
		}
        _currentWeapon = _weapons[index];
		_currentWeapon.SetActive(true);
    }

    private void Update(){
        if(Input.GetButton("Fire1") && isPlayer){
            targetVector = _weaponPoint.position + _weaponPoint.forward;
            Attack(targetVector); 
        }
        if(!isPlayer){ 

            _target = GameObject.FindGameObjectWithTag("Player");
            Attack(_target.transform.position - _weaponPoint.position); 
        }
    }

    public void Attack(Vector3 target){
        if(_currentWeapon.TryGetComponent(out IAttack attack)){
            attack.Attack(1f, target);
            
        }
    }
}
