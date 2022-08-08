using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform player;
    private Vector3 PlayerPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void FixedUpdate()
    {
        PlayerPosition = new Vector3(player.position.x, player.position.y + 30, player.position.z - 10);
        gameObject.GetComponentInChildren<Transform>().LookAt(player);
        if(Mathf.Abs(player.position.z - gameObject.transform.position.z) > 1f || Mathf.Abs(player.position.x - gameObject.transform.position.x) > 2f)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, PlayerPosition, Time.deltaTime * 7f);
        }

    }
}
