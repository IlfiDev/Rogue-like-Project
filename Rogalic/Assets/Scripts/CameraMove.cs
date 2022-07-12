using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform player_coordinates;
    private Transform camera_coordinates;

    private float x = 0;
    private float z = 0;
    // Start is called before the first frame update
    void Start()
    {
        camera_coordinates = GameObject.Find("Main Camera").transform; 
        player_coordinates = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player_coordinates.position.x != x || player_coordinates.position.z != z)
        {
            Vector3 vector3 = new Vector3(player_coordinates.position.x + 1, 15, player_coordinates.position.z - 23);
            camera_coordinates.position = vector3 * Time.deltaTime;
            x = player_coordinates.position.x;
            z = player_coordinates.position.z;
        }
    }
}