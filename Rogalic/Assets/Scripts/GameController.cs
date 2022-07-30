using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    public GameObject StartRoom;
    public GameObject Room;
    public GameObject enemy;
    public GameObject player;
    private GameObject playerSpawnPoint;
    public Vector3 spawnValues;
    public GameObject main_camera;

    float startRoomSizeX;
    float startRoomSizeZ;
    float startRoomPositionX;
    float startRoomPositionZ;

    void Start()
    {
        startRoomSizeX = StartRoom.transform.localScale.x;
        startRoomSizeZ = StartRoom.transform.localScale.z;

        startRoomPositionX = StartRoom.transform.position.x;
        startRoomPositionZ = StartRoom.transform.position.z;

        CreateStartRoom();
        GenerateRooms();

        playerSpawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawnPoint");

        SpawnPlayer();
        SpawnCamera();
        SpawnCreature();
    }

    void CreateStartRoom()
    {
        Vector3 spawnPosition = new Vector3(0f, 0f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(StartRoom, spawnPosition, spawnRotation);
    }

    void SpawnCreature()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-startRoomSizeX / 2 + 5, startRoomSizeX / 2 - 5), 1f, Random.Range(-startRoomSizeZ / 2 + 5, startRoomSizeZ / 2 - 5));
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

    //void SpawnWayPoints()
    //{
    //    for (int i = 0; i < 100; i++)
    //    {
    //        Vector3 spawnPosition = new Vector3(Random.Range(-platformSizeX / 2 + 5, platformSizeX / 2 - 5), 1f, Random.Range(-platformSizeZ / 2 + 5, platformSizeZ / 2- 5));
    //        Quaternion spawnRotation = Quaternion.identity;

    //        Instantiate(wayPoint, spawnPosition, spawnRotation, PointsFolder.transform);
    //    }
    //}

    void GenerateRooms()
    {
        int[,] map = {{ },{ }};



        Vector3 spawnPosition = new Vector3(startRoomPositionX + startRoomSizeX, 0f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(Room, spawnPosition, spawnRotation);        
    }
}
