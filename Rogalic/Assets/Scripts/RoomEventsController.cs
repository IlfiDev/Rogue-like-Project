using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct WaveInfo{
    public List<GameObject> SpawnPoints;
    public List<GameObject> Enemies;
}

public class RoomEventsController : MonoBehaviour
{
    [SerializeField] private List<WaveInfo> _waveInfo; 
    [SerializeField] private List<GameObject> _randomWeapons;
    [SerializeField] private int _waveCounter = 0;
    [SerializeField] private List<GameObject> _currentEnemies;
    [SerializeField] private Transform weaponPosition;
    private GameObject _chosenWeapon;

    private void Start(){
        _chosenWeapon = Instantiate(_randomWeapons[Random.Range(0, _randomWeapons.Count)], weaponPosition.position, weaponPosition.rotation);

    }
    private void Update(){
        _currentEnemies.RemoveAll(s => s == null);
        if(_chosenWeapon.transform.position != weaponPosition.position && _waveCounter == 0){
            StartWave(0);
        }
        if(_waveCounter != 0 && _currentEnemies.Count == 0){
            StartWave(_waveCounter);
        }
    }
    private void StartWave(int index){
        SpawnEnemies(index);
        _waveCounter++;
    }


    private void SpawnEnemies(int waveIndex){
        foreach(GameObject point in _waveInfo[waveIndex].SpawnPoints){
            GameObject enemy = Instantiate(_waveInfo[waveIndex].Enemies[Random.Range(0, _waveInfo[waveIndex].Enemies.Count)], point.transform.position, point.transform.rotation);
            _currentEnemies.Add(enemy);
        }
    }
        
 
}


