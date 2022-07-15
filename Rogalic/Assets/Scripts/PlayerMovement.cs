
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Transform player_coordinates;

    [SerializeField] private CharacterController characterController;

    [SerializeField] private static float Speed = 10f;
    [SerializeField] private static float ShiftSpeed = Speed * 2;
    [SerializeField] private static float JumpForce = 10f;
    [SerializeField] private static float Gravity = -9.81f;

    private void Awake()
    {
        player_coordinates = GameObject.FindGameObjectWithTag("Player").transform;
        characterController = this.GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        
        float x = Input.GetAxis("Vertical");
        float z = -Input.GetAxis("Horizontal");
        
        Vector3 move_x_z = new Vector3(x, 0, z);
        Vector3 Velocity = Vector3.zero;

        if (characterController.isGrounded)
        {
            Velocity.y = -2f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Velocity.y = Mathf.Sqrt(PlayerMovement.JumpForce * -2f * PlayerMovement.Gravity);
            }

        }
        else
        {
            Velocity.y -= PlayerMovement.Gravity * -4f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(x != 0 && z != 0)
            {
                characterController.Move(move_x_z * (PlayerMovement.ShiftSpeed / 2) * Time.deltaTime);
            } else
            {
                characterController.Move(move_x_z * PlayerMovement.ShiftSpeed * Time.deltaTime);
            }
        } else
        {
            if (x != 0 && z != 0)
            {
                characterController.Move(move_x_z * (PlayerMovement.Speed / 2) * Time.deltaTime);
            }
            else
            {
                characterController.Move(move_x_z * PlayerMovement.Speed * Time.deltaTime);
            }
        }
        characterController.Move(Velocity * Time.deltaTime);

        if(move_x_z != Vector3.zero)
        {
            float RotationSpeed = 720;
            Quaternion Rotation = Quaternion.LookRotation(move_x_z, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, RotationSpeed * Time.deltaTime);
        }
    }
}
