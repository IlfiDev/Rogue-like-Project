using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform player;
    Vector3 defaul_position = new Vector3(-18.85f, 28.6f, -18.35f);

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 new_cam_position = new Vector3(defaul_position.x + player.position.x, defaul_position.y + player.position.y,
            defaul_position.z + player.position.z);
        transform.position = new_cam_position;
    }
}
