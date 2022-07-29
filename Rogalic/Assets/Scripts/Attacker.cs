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
    [SerializeField] private List<GameObject> _weapons;
    private List<GameObject> _projectiles = new List<GameObject>();

    private void Start(){
        _currentWeapon = Instantiate(_weapons[0], _weaponPoint.position, _weaponPoint.rotation);
        _currentWeapon.transform.parent = _weaponPoint.parent;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (!isPlayer){
            _target = GameObject.FindGameObjectWithTag("Player");
        }
    }
    
    public void UpdateWeapon(GameObject newWeapon){
        _currentWeapon = newWeapon;
    }

    private void Update(){
        if(Input.GetButton("Fire1") && isPlayer){
            targetVector = _weaponPoint.position + _weaponPoint.forward;
            Attack(targetVector); 
        }
        if(Input.GetButton("Fire1") && !isPlayer){
            
            Attack(_target.transform.position - _weaponPoint.position); 
        }
    }

    public void Attack(Vector3 target){
        if(_currentWeapon.TryGetComponent(out IAttack attack)){
            
            attack.Attack(1f, target);
            
        }
    }
}
