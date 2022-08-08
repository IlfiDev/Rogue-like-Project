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

    public GameObject simple_enemy;
    public GameObject chest;
    public GameObject player_screen;
    public GameObject tooltip;

    void Start()
    {
        CreateStartRoom();
        SpawnLight();
        playerSpawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawnPoint");
        SpawnPlayer();
        SpawnCamera();

        SpawnSimpleEnemy();
        SpawnChest();
        SpawnUserUI();
        SpawnTooltip();
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
        GameObject TruePlayer = GameObject.FindGameObjectWithTag("Player");
        Vector3 spawnPosition = new Vector3(TruePlayer.transform.position.x, TruePlayer.transform.position.y, TruePlayer.transform.position.z);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(main_camera, spawnPosition, spawnRotation);
    }

    public void RespawnPlayer()
    {
        Debug.Log("Respawn player");
        Vector3 spawnPosition = new Vector3(0f, 1f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        GameObject temp_player = GameObject.FindGameObjectWithTag("Player");

        CharacterController characterController = temp_player.GetComponent<CharacterController>();
        characterController.enabled = false;

        Transform player_coordinates = temp_player.GetComponent<Transform>();
        player_coordinates.SetPositionAndRotation(spawnPosition, spawnRotation);

        characterController.enabled = true;
    }

    void SpawnSimpleEnemy()
    {
        Vector3 spawnPosition = new Vector3(0f, 1f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(simple_enemy, spawnPosition, spawnRotation);
    }

    public void SpawnChest()
    {
        Vector3 spawnPosition = new Vector3(5f, 1f, 5f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(chest, spawnPosition, spawnRotation);
    }

    void SpawnUserUI()
    {
        Vector3 spawnPosition = new Vector3(0f, 0f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(player_screen, spawnPosition, spawnRotation);
    }

    void SpawnTooltip()
    {
        Vector3 spawnPosition = new Vector3(0f, 0f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(tooltip, spawnPosition, spawnRotation);
    }
}
