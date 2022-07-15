
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Transform player_coordinates;

    [SerializeField] private CharacterController characterController;

    [SerializeField] private static float Speed = 10f;
    [SerializeField] private static float ShiftSpeed = Speed * 2;

    private void Awake()
    {
        player_coordinates = GameObject.FindGameObjectWithTag("Player").transform;
        characterController = this.GetComponent<CharacterController>();
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        ShitMoveVersion();
    }

    private void GoodMoveVersion()
    {
        float x = Input.GetAxis("Vertical");
        float z = -Input.GetAxis("Horizontal");

        Vector3 move_x_z = new Vector3(x, 0, z);

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

        if(move_x_z != Vector3.zero)
        {
            float RotationSpeed = 720;
            Quaternion Rotation = Quaternion.LookRotation(move_x_z, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, RotationSpeed * Time.deltaTime);
        }
    }

    private void ShitMoveVersion()
    {
        float x = Input.GetAxis("Vertical");
        float z = -Input.GetAxis("Horizontal");

        Vector3 move_x_z = Vector3.zero;

        if (x != 0 && z == 0)
        {
            move_x_z = new Vector3(x, 0, x);
        }

        if (z != 0 && x == 0)
        {
            move_x_z = new Vector3(-z, 0, z);
        }

        if (x != 0 && z != 0)
        {
            if (x > 0 && z > 0)
            {
                move_x_z = new Vector3(0, 0, z);
            }

            if (x < 0 && z > 0)
            {
                move_x_z = new Vector3(x, 0, 0);
            }

            if (x < 0 && z < 0)
            {
                move_x_z = new Vector3(0, 0, z);
            }

            if (x > 0 && z < 0)
            {
                move_x_z = new Vector3(x, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (x != 0 && z != 0)
            {
                characterController.Move(move_x_z * PlayerMovement.ShiftSpeed * Time.deltaTime);
            }
            else
            {
                characterController.Move(move_x_z * (PlayerMovement.ShiftSpeed / 2) * Time.deltaTime);
            }
        }
        else
        {
            if (x != 0 && z != 0)
            {
                characterController.Move(move_x_z * PlayerMovement.Speed * Time.deltaTime);
            }
            else
            {
                characterController.Move(move_x_z * (PlayerMovement.Speed / 2) * Time.deltaTime);
            }
        }

        if (move_x_z != Vector3.zero)
        {
            float RotationSpeed = 720;
            Quaternion Rotation = Quaternion.LookRotation(move_x_z, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, RotationSpeed * Time.deltaTime);
        }

    }
}
