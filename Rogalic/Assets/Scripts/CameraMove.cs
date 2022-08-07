using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform player;
    Vector3 defaul_position = new Vector3(-0.16f, 30.3f, -5.5f);

    private void Awake()
    {
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 new_cam_position = new Vector3(defaul_position.x + player.position.x, defaul_position.y + player.position.y,
            defaul_position.z + player.position.z);
        transform.position = new_cam_position;
    }
}
