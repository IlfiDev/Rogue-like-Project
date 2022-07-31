using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : MonoBehaviour
{
    private float RoomSizeX;
    private float RoomSizeZ;

    GameObject connector;

    public float GetStartRoomSizeX()
    {
        return RoomSizeX;
    }
    public float GetStartRoomSizeZ()
    {
        return RoomSizeZ;
    }

    void Start()
    {
        GameObject startRoomFloor = GameObject.FindGameObjectWithTag("StartRoomFloor");
        RoomSizeX = startRoomFloor.transform.localScale.x;
        RoomSizeZ = startRoomFloor.transform.localScale.z;
    }

    void Update()
    {

    }
}
