using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _defaultWeapon;
    private int _slotIndex = 0;
    [SerializeField] private List<GameObject> _weapons = new List<GameObject>();
    [SerializeField] private Transform _weaponPoint;
    private AttackerNew _attacker;
    void Start()
    {
        _attacker = gameObject.GetComponent<AttackerNew>();
        for(int i = 0; i < 3; i++) {
            _weapons.Add(_defaultWeapon);
            _weapons[i] = Instantiate(_weapons[i], _weaponPoint.position, _weaponPoint.rotation);
            _weapons[i].transform.parent = _weaponPoint.parent;
            _weapons[i].SetActive(false);
        }
        _weapons[0].SetActive(true);
        _attacker.SetWeapon(_weapons[0]);
    }

    // Update is called once per frame
    public void UpdateWeapon(int index, GameObject weapon){
        if (weapon == null){
            if(_weapons[index].transform.tag == _defaultWeapon.transform.tag){
                Destroy(_weapons[index]);
            }
            _weapons[index].transform.parent = null;
            _weapons[index] = Instantiate(_defaultWeapon, _weaponPoint.position, _weaponPoint.rotation);
        }
        else{
            if(_weapons[index].transform.tag == _defaultWeapon.transform.tag){
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
            _attacker.SetWeapon(_weapons[index]);
        }
        _weapons[index].transform.parent = _weaponPoint.parent;
    }

    public void SwitchWeapon(int index){
        foreach(GameObject weapon in _weapons){
            weapon.SetActive(false);
        }
        _slotIndex = index;
        _weapons[index].SetActive(true);
        _attacker.SetWeapon(_weapons[index]);
    }
}
