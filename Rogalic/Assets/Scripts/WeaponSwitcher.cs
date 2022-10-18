using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _defaultWeapon;
    private int _slotIndex = 0;
    [SerializeField] private List<GameObject> _weapons = new List<GameObject>();
    [SerializeField] private Transform _weaponPoint;
    [SerializeField]private AttackerNew _attacker;
    [SerializeField] private Transform[] _imya;
        
    void Awake(){
        _imya = gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform trans in _imya){
            if(trans.tag == "WeaponPoint"){
                _weaponPoint = trans;
            }
        }
    }
    void Start()
    {
        
        _attacker = gameObject.GetComponent<AttackerNew>();
        
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

    public void InitWeapons(){
        if(_weapons == null){
            Debug.Log("Cock Dick");
        }
        Debug.Log(_weaponPoint);
        for(int i = 0; i < 3; i++) {
            GameObject obj = Instantiate(
                        _defaultWeapon,
                        _weaponPoint.position,
                        _weaponPoint.rotation);
            _weapons.Add(obj);
            _weapons[i].transform.parent = _weaponPoint.parent;
            if(_weapons[i].transform.tag != _defaultWeapon.transform.tag){
                _weapons[i].GetComponent<Interactible>().enabled = false;
            }
            _weapons[i].SetActive(false);
        }
        _weapons[0].SetActive(true);
        _attacker.SetWeapon(
                _weapons[0]);
    }
    public void SetDefaultWeapon(GameObject weapon){
        _defaultWeapon = weapon;
    }
    public void SetAttacker(AttackerNew attacker){
        _attacker = attacker;
    }
}
