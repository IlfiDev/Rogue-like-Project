using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerNew : MonoBehaviour
{
    [SerializeField] public Transform _weaponPoint;
    private GameObject physicalWeapon;
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _currentWeapon;
    private Vector3 targetVector;
    [SerializeField] bool isPlayer = false;
    private List<GameObject> _projectiles = new List<GameObject>();
	private int _slotIndex = 0;
    [SerializeField] private Transform[] _transformName;
    // Start is called before the first frame update
    void Awake(){
        _transformName= gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform trans in _transformName){
            if(string.Equals(trans.tag, "WeaponPoint")){
                _weaponPoint = trans;
            }
        }
    }
    void Start()
    {
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    public void UpdateWeapon(GameObject weapon){
        _currentWeapon = weapon;
    }
    void Update()
    {
        if(isPlayer){
            targetVector = _weaponPoint.position + _weaponPoint.forward;
            if(Input.GetButton("Fire1")){
                PrimaryAttack(targetVector);
            }
            if(Input.GetButton("Fire2")){
                SecondaryAttack(targetVector);
            }
        }
        else
        {
            _target = GameObject.FindGameObjectWithTag("Player");
            //PrimaryAttack((_weaponPoint.forward * 1.5f + _weaponPoint.position));
        }
    }

    public void PrimaryAttack(Vector3 target){
        if(_currentWeapon.TryGetComponent(out IAttack attack)){
            attack.PrimaryAttack(1f, target);
        }
    }
    public void SecondaryAttack(Vector3 target){
        if(_currentWeapon.TryGetComponent(out IAttack attack)){
            attack.SecondaryAttack(1f, target);
        }
    }
    public Vector3 GetTargetVector(){
        return _target.transform.position;
    }
    public void SetWeapon(GameObject weapon){
        _currentWeapon = weapon;
    }
    public void SetAsPlayer(){
        isPlayer = true;
    }
}
