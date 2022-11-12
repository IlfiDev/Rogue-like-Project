using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameController : MonoBehaviour
{
    public GameObject StartRoom;
    public GameObject player;
    public GameObject main_camera;
    public GameObject lighter;

    private GameObject playerSpawnPoint;

    public GameObject simple_enemy;
    public GameObject chest;
    public GameObject player_screen;
    public GameObject tooltip;

    public GameObject zxc;

    GameObject tempPlayer = null;

    void Start()
    {
        CreateStartRoom();
        SpawnLight();
        playerSpawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawnPoint");
        SpawnPlayer();
        SpawnCamera();
        SpawnUserUI();
        SpawnTooltip();
        SpawnZxc();


        tempPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (tempPlayer.GetComponent<Player>().isDead == true)
        {
            StartCoroutine(onDeathWait(2f));
            tempPlayer.GetComponent<Player>().isDead = false;
        }
    }

    void SpawnZxc()
    {
        Vector3 spawnPosition = new Vector3(0f, 20f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(zxc, spawnPosition, spawnRotation);
    }

    void SpawnLight()
    {
        Vector3 spawnPosition = new Vector3(0f, 20f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(lighter, spawnPosition, spawnRotation);
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

    public IEnumerator onDeathWait(float waitTime)
    {
        tempPlayer.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        tempPlayer.SetActive(true);
        tempPlayer.GetComponent<Player>().canBeRespawned = true;
    }
}
