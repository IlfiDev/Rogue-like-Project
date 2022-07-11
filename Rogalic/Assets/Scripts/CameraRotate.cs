using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float mouseSens = 1500f;

    private Transform player_coordinates;
    private float yRotation;
    void Start()
    {
        player_coordinates = GameObject.Find("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        player_coordinates.Rotate(Vector3.up * mouseX);
    }
}
