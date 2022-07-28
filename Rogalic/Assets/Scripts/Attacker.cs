using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _weaponPoint;
    private GameObject physicalWeapon;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject _currentWeapon;
    private Vector3 targetVector;
    [SerializeField] bool isPlayer = false;
    private List<GameObject> _projectiles = new List<GameObject>();

    private void Start(){
        //physicalWeapon = Instantiate(_currentWeapon, _weaponPoint.position, Quaternion.identity);
        //weapon.transform.parent = _weaponPoint.parent;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (!isPlayer){
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
    
    public void UpdateWeapon(GameObject newWeapon){
        _currentWeapon = newWeapon;
    }

    private void Update(){
        //physicalWeapon.transform.position = _weaponPoint.position;
        Debug.Log("Dick");
        if(Input.GetButton("Fire1") && isPlayer){
            targetVector = _weaponPoint.position + _weaponPoint.forward;
            //targetVector = shootingPoint.position + shootingPoint.forward;
            Attack(targetVector); 
        }
    }

    public void Attack(Vector3 target){
        if(_currentWeapon.TryGetComponent(out IAttack attack)){
            
            attack.Attack(1f, target);
            // foreach(var projectile in _projectiles)
            //     Destroy(projectile, 2f);
        }
        
        // GameObject bullet = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);

        // Vector3 shootDir = (target - shootingPoint.position).normalized;
        // bullet.GetComponent<BulletBehaviour>().Setup(shootDir);
        
    }
}
