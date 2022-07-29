using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform cam_position;

    private void Start()
    {
        cam_position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam_position.forward);
    }
}
