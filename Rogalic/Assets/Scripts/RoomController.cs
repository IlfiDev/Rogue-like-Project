using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Transform NextRoomStands;
    public Transform NextRooms;

    private GameObject OutDoor;
    private GameObject InDoor;
    private Transform RoomRight;
    private Transform RoomLeft;

    private Vector3 OutDoorPositionNew;
    private Vector3 InDoorPositionNew;

    private string TriggerName;

    private float RoomSizeX;
    private float RoomSizeZ;

    List<Transform> stands = new List<Transform>();
    Transform[] standsArray;
    List<Transform> Rooms = new List<Transform>();

    private bool DoorIsOpen = false;

    void Start()
    {
        OutDoor = GameObject.FindGameObjectWithTag("Door");
        InDoor = GameObject.FindGameObjectWithTag("InConnector");
        OutDoorPositionNew = new Vector3(OutDoor.transform.position.x, OutDoor.transform.position.y + 5, OutDoor.transform.position.z);
        InDoorPositionNew = new Vector3(InDoor.transform.position.x, InDoor.transform.position.y - 5, InDoor.transform.position.z);
        foreach (Transform child in NextRoomStands)
        {
            stands.Add(child);
        }
        foreach (Transform child in NextRooms)
        {
            Rooms.Add(child);
        }
        CreateStands();
    }

    void Update()
    {
        if (TriggerName == "button_right")
        {
            CreateNextRoom(RoomRight);
            TriggerName = "";
            DoorIsOpen = true;
        }
        if (TriggerName == "button_left")
        {
            CreateNextRoom(RoomLeft);
            TriggerName = "";
            DoorIsOpen = true;
        }
        if (TriggerName == "Trigger")
        {
            InDoor.transform.position = Vector3.Lerp(InDoor.transform.position, InDoorPositionNew, Time.deltaTime * 5f);
        }
        if (DoorIsOpen == true)
        {
            OutDoor.transform.position = Vector3.Lerp(OutDoor.transform.position, OutDoorPositionNew, Time.deltaTime * 5f);
        }
    }

    void CreateNextRoom(Transform room)
    {
        Vector3 spawnPosition = new Vector3(0f, 0f, 50f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(room, spawnPosition, spawnRotation);
    }

    void CreateStands()
    {
        standsArray = stands.ToArray();
        Transform[] GeneratedStands = new Transform[2];
        GeneratedStands = ChooseSet(2);
        string roomNameOne = GeneratedStands[0].name;
        string roomNameTwo = GeneratedStands[1].name;
        foreach (Transform room in Rooms)
        {
            if(room.name == roomNameOne)
            {
                RoomRight = room;
            }
            if (room.name == roomNameTwo)
            {
                RoomLeft = room;
            }
        }
        GameObject StandRight = GameObject.FindGameObjectWithTag("StandRight");
        GameObject StandLeft = GameObject.FindGameObjectWithTag("StandLeft");
        Vector3 StandRightPos = StandRight.GetComponent<Transform>().position;
        Vector3 StandLeftPos = StandLeft.GetComponent<Transform>().position;
        Quaternion spawnRotation = Quaternion.identity;
        Vector3 StandRightPosNew = new Vector3(StandRightPos.x, StandRightPos.y + 1, StandRightPos.z);
        Vector3 StandLeftPosNew = new Vector3(StandLeftPos.x, StandLeftPos.y + 1, StandLeftPos.z);
        Instantiate(GeneratedStands[0], StandRightPosNew, spawnRotation);
        Instantiate(GeneratedStands[1], StandLeftPosNew, spawnRotation);
    }

    Transform[] ChooseSet(int numRequired)
    {
        Transform[] result = new Transform[numRequired];
        int numToChoose = numRequired;
        for (int numLeft = standsArray.Length; numLeft > 0; numLeft--)
        {
            float prob = (float)numToChoose / (float)numLeft;

            if (Random.value <= prob)
            {
                numToChoose--;
                result[numToChoose] = standsArray[numLeft - 1];

                if (numToChoose == 0)
                {
                    break;
                }
            }
        }
        return result;
    }

    public void SetTriggerName(string TriggerName)
    {
        this.TriggerName = TriggerName;
    }
}