using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRoomQuest : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameObject.GetComponent<RoomController>().SetRoomComplition();
        }
    }
}
