using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomController : MonoBehaviour
{
    private Transform[] AllRooms;

    private Transform OutDoor;
    private Transform InDoor;
    private Transform StandRight;
    private Transform StandLeft;
    private Transform MyFloor;

    private string MyTag;
    
    private Vector3 OutDoorPositionNew;
    private Vector3 InDoorPositionNew;

    private string TriggerName;

    private float MySizeX;
    private float MySizeZ;

    List<Transform> NextRooms = new List<Transform>();
    Transform[] NextRoomsArray = new Transform[2];
    List<Transform> stands = new List<Transform>();
    Transform[] standsArray;

    List<string> StageTags = new List<string>() {"StartRoom", "Stage_1_Room", "Stage_2_Room", "Stage_3_Room", "FinishRoom"};

    private bool DoorIsOpen = false;
    private bool RoomIsComplited = true;

    void Start()
    {
        MyTag = gameObject.tag;
        FindMyObjects();
        MySizeX = MyFloor.localScale.x;
        MySizeZ = MyFloor.localScale.z;
        AllRooms = Resources.LoadAll<Transform>("Rooms");
        if (MyTag != "FinishRoom")
        {
            FindNextRooms();
            ChooseNextRooms(NextRooms.ToArray());
            CreateStands();
        }   
    }

    void Update()
    {
        if (DoorIsOpen == false && RoomIsComplited == true)
        {
            if (TriggerName == "button_right")
            {
                CreateNextRoom(NextRoomsArray[0]);
                DoorIsOpen = true;
            }
            if (TriggerName == "button_left")
            {
                CreateNextRoom(NextRoomsArray[1]);
                DoorIsOpen = true;
            }
        }
        
        if (TriggerName == "Trigger")
        {
            try
            {
                InDoor.transform.position = Vector3.Lerp(InDoor.transform.position, InDoorPositionNew, Time.deltaTime * 5f);
            }
            catch { }
            try
            {
                int i = 0;
                GameObject[] StandsOnScene = GameObject.FindGameObjectsWithTag("RoomStand");
                while(i < StageTags.Count)
                {
                    if (StageTags[i] == MyTag)
                    {
                        GameObject PreviousRoom = GameObject.FindGameObjectWithTag(StageTags[i - 1]);
                        Destroy(PreviousRoom);
                    }
                    if (StandsOnScene[i].transform.position.z < gameObject.transform.position.z)
                    {
                        Destroy(StandsOnScene[i]);
                    }
                    i++;
                }
            }
            catch { }
        }
        if (DoorIsOpen == true)
        {
            OutDoor.transform.position = Vector3.Lerp(OutDoor.transform.position, OutDoorPositionNew, Time.deltaTime * 5f);
            if (OutDoor.transform.position.y > OutDoorPositionNew.y - 0.1)
            {
                OutDoor.GetComponent<Renderer>().enabled = false;
            }
        }
        if (TriggerName != "Trigger")
        {
            TriggerName = "";
        }
    }

    void FindMyObjects()
    {
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.tag == "Door")
                OutDoor = child;
            if (child.tag == "InConnector")
                InDoor = child;
            if (child.tag == "StandRight")
                StandRight = child;
            if (child.tag == "StandLeft")
                StandLeft = child;
            if (child.tag == "RoomFloor")
                MyFloor = child;
        }

        try
        {
            OutDoorPositionNew = new Vector3(OutDoor.transform.position.x, OutDoor.transform.position.y + 5, OutDoor.transform.position.z);
        }
        catch { }
        
        try
        {
            InDoorPositionNew = new Vector3(InDoor.transform.position.x, InDoor.transform.position.y - 5, InDoor.transform.position.z);
        }
        catch { }

        MySizeX = MyFloor.transform.localScale.x;
        MySizeZ = MyFloor.transform.localScale.z;
    }

    void FindNextRooms()
    {
        string targetRoomTag = null;
        if (MyTag == "StartRoom") { targetRoomTag = "Stage_1_Room"; }
        if (MyTag == "Stage_1_Room") { targetRoomTag = "Stage_2_Room"; }
        if (MyTag == "Stage_2_Room") { targetRoomTag = "Stage_3_Room"; }
        if (MyTag == "Stage_3_Room") { targetRoomTag = "FinishRoom"; }
        foreach (Transform room in AllRooms)
        {
            if (room.tag == targetRoomTag)
            {
               NextRooms.Add(room);
            }
        }
    }

    void ChooseNextRooms(Transform[] array)
    {
        int size = array.Length;
        int firstIndex = 0;
        int secondIndex = 0;
        while (firstIndex == secondIndex)
        {
            firstIndex = Random.Range(0, size);
            secondIndex = Random.Range(0, size);
        }
        NextRoomsArray[0] = array[firstIndex];
        NextRoomsArray[1] = array[secondIndex];
    }

    void CreateStands()
    {
        foreach (Transform room in NextRoomsArray)
        {
            foreach (Transform child in room.GetComponentsInChildren<Transform>())
            {
                if (child.tag == "RoomStand") { stands.Add(child); }
            }
        }
        standsArray = stands.ToArray();
        Vector3 StandRightPos = StandRight.GetComponent<Transform>().position;
        Vector3 StandLeftPos = StandLeft.GetComponent<Transform>().position;
        Quaternion spawnRotation = Quaternion.identity;
        Vector3 StandRightPosNew = new Vector3(StandRightPos.x, StandRightPos.y + 1, StandRightPos.z);
        Vector3 StandLeftPosNew = new Vector3(StandLeftPos.x, StandLeftPos.y + 1, StandLeftPos.z);
        Instantiate(standsArray[0], StandRightPosNew, spawnRotation);
        Instantiate(standsArray[1], StandLeftPosNew, spawnRotation);
    }

    void CreateNextRoom(Transform room)
    {
        float roomSizeZ = 0;
        foreach (Transform child in room.GetComponentsInChildren<Transform>())
        {
            if (child.tag == "RoomFloor")
                roomSizeZ = child.transform.localScale.z;
        }
        Vector3 spawnPosition = new Vector3(0f, 0f, gameObject.transform.position.z + (MySizeZ/2 + roomSizeZ/2));
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(room, spawnPosition, spawnRotation);
    }

    public void SetTriggerName(string TriggerName)
    {
        this.TriggerName = TriggerName;
    }

    public void SetRoomComplition()
    {
        this.RoomIsComplited = true;
    }
}