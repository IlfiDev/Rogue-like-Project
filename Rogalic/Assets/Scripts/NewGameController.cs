using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameController : MonoBehaviour
{
    public GameObject StartRoom;
    public GameObject player;
    public GameObject main_camera;
    public GameObject light;

    private GameObject playerSpawnPoint;

    List<Transform> stands = new List<Transform>();
    Transform[] standsArray;

    void Start()
    {
        CreateStartRoom();
        SpawnLight();
        playerSpawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawnPoint");
        SpawnPlayer();
        SpawnCamera();
    }

    void Update()
    {
        
    }

    void SpawnLight()
    {
        Vector3 spawnPosition = new Vector3(0f, 20f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(light, spawnPosition, spawnRotation);
    }

    void CreateStartRoom()
    {
        Vector3 spawnPosition = new Vector3(0f, 0f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(StartRoom, spawnPosition, spawnRotation);
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
}
