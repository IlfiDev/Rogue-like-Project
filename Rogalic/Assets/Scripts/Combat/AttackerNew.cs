using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerNew : MonoBehaviour
{
    [SerializeField] private Transform _weaponPoint;
    private GameObject physicalWeapon;
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _currentWeapon;
    private Vector3 targetVector;
    [SerializeField] bool isPlayer = false;
    private List<GameObject> _projectiles = new List<GameObject>();
	private int _slotIndex = 0;
    // Start is called before the first frame update
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
}
