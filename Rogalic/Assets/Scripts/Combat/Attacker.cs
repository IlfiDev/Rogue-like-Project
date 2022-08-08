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
	[SerializeField] private List<GameObject> _weapons = new List<GameObject>();
    private List<GameObject> _projectiles = new List<GameObject>();
	[SerializeField] private GameObject _defaultWeapon;
	private int _slotIndex = 1;
    private void Start(){
		for(int i = 0; i < 3; i++){

			_weapons.Add(_defaultWeapon);
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

	public void GetWeapons(List<GameObject> weapons){
		_weapons = weapons;
        
	}
	public void UpdateWeapon(int index, GameObject weapon){
		if (weapon == null){
			_weapons[index].transform.parent = null;
			if(_wepons[index].transform.tag == "Fists"){
				Destroy(_weapons[index]);
			}
			_weapons[index] = Instantiate(_defaultWeapon, _weaponPoint.position, _weaponPoint.rotation);
			_weapons[index].transform.parent = transform;
		}
		else{
			if (_weapons[index].transform.tag == "Fists"){

			Destroy(_weapons[index]);
			}
			else{
			_weapons[index].transform.parent = null;

			}
			_weapons[index] = weapon;
			_weapons[index].transform.position = _weaponPoint.position;
			_weapons[index].transform.rotation = _weaponPoint.rotation;
		}
		if (index == _slotIndex){
			_currentWeapon = _weapons[index];
		}
		_weapons[index].transform.parent = _weaponPoint.parent;
	}
    public void SwitchWeapon(int index){
		foreach(GameObject weapon in _weapons){
			weapon.SetActive(false);
		}
		_slotIndex = index;
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
