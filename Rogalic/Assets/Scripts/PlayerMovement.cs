
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Transform player_coordinates;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera cam;

    [SerializeField] private float Speed = 10f;
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private float Gravity = -9.81f;
    [SerializeField] private float mouseSens = 1500f;

    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;
    private void Start()
    {
        player_coordinates = GameObject.Find("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        characterController = this.GetComponent<CharacterController>();
    }

    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move_x_z = new Vector3(x, 0, y);

        //Vector3 move_x_z = transform.right * x + transform.forward * y;

        if (characterController.isGrounded)
        {
            Velocity.y = -2f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Velocity.y = Mathf.Sqrt(JumpForce * -2f * Gravity);
            }

        }
        else
        {
            Velocity.y -= Gravity * -4f * Time.deltaTime;
        }
        characterController.Move(move_x_z * Speed * Time.deltaTime);
        characterController.Move(Velocity * Time.deltaTime);

        /*
        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");

        player_coordinates.Rotate(Vector3.up * mouse_x);
        player_coordinates.Rotate(Vector3.down * mouse_y);
        */

        //float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        //player_coordinates.Rotate(Vector3.up * mouseX);

        //player_coordinates.Rotate(0, Input.GetAxis("Mouse X"), 0);
        /*
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = new Vector2(player_coordinates.position.x - mousePos.x, player_coordinates.position.z - mousePos.y);
        float angle_rot = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        player_coordinates.eulerAngles = new;
        */

    }


}
