using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public RoomController room;

    public GameObject enemyPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            room.SetTriggerName(gameObject.name);
    }
}
