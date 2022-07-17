using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject platform;
    public GameObject enemy;
    public GameObject wayPoint;
    public GameObject PointsFolder;
    public GameObject player;
    public GameObject playerSpawnPoint;
    public Vector3 spawnValues;
    public GameObject main_camera;

    float platformSizeX;
    float platformSizeZ;    

    void Start()
    {
        platformSizeX = platform.transform.localScale.x;
        platformSizeZ = platform.transform.localScale.z;

        SpawnPlayer();
        SpawnCamera();
        SpawnWayPoints();
        SpawnCreature();
    }

    void SpawnCreature()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-platformSizeX / 2 + 5, platformSizeX / 2 - 5), 1f, Random.Range(-platformSizeZ / 2 + 5, platformSizeZ / 2 - 5));
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(enemy, spawnPosition, spawnRotation);  
    }

    void SpawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(playerSpawnPoint.transform.position.x, 1f, playerSpawnPoint.transform.position.z);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(player, spawnPosition, spawnRotation);
    }

    void SpawnCamera()
    {
        Vector3 spawnPosition = new Vector3(playerSpawnPoint.transform.position.x, 1f, playerSpawnPoint.transform.position.z);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(main_camera, spawnPosition, spawnRotation);
    }

    void SpawnWayPoints()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-platformSizeX / 2 + 5, platformSizeX / 2 - 5), 1f, Random.Range(-platformSizeZ / 2 + 5, platformSizeZ / 2- 5));
            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(wayPoint, spawnPosition, spawnRotation, PointsFolder.transform);
        }
    }
}
