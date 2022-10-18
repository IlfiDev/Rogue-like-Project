
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IKnockable
{
    [SerializeField] public Transform player_coordinates;

    [SerializeField] private CharacterController characterController;

    [SerializeField] private static float Speed;
    [SerializeField] private static float ShiftSpeed;
    [SerializeField] private static float Gravity;
    [SerializeField] private float _mass = 1f;
    public Vector3 _impact;

    private void Start()
    {
        player_coordinates = gameObject.GetComponent<Transform>();
        characterController = gameObject.GetComponent<CharacterController>();

        Unit player_info = gameObject.GetComponent<Unit>();
        Speed = player_info.getMoveSpeed();
        ShiftSpeed = Speed * 2;
        Gravity = player_info.getGravity();
    }

    private void Update()
    {
        SecondGoodMoveVersion();
    }

    private void FixedUpdate(){
        if(_impact.magnitude > 0.2){
            characterController.Move(_impact * Time.deltaTime);
        }
        _impact = Vector3.Lerp(_impact, Vector3.zero, 5 * Time.deltaTime);
    }
    public void SecondGoodMoveVersion()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move_x_z = new Vector3(x, 0, z);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (x != 0 && z != 0)
            {
                characterController.Move(move_x_z * (PlayerMovement.ShiftSpeed) * Time.deltaTime);
            }
            else
            {
                characterController.Move(move_x_z * PlayerMovement.ShiftSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (x != 0 && z != 0)
            {
                characterController.Move(move_x_z * (PlayerMovement.Speed) * Time.deltaTime);
            }
            else
            {
                characterController.Move(move_x_z * PlayerMovement.Speed * Time.deltaTime);
            }
        }

        Vector3 gravity = Vector3.zero;
        if (characterController.isGrounded)
        {
            gravity.y = -2f;
        }
        else
        {
            gravity.y -= PlayerMovement.Gravity * -4f * Time.deltaTime;
        }
        characterController.Move(gravity);

        if (move_x_z != Vector3.zero)
        {
            float RotationSpeed = 720;
            Quaternion Rotation = Quaternion.LookRotation(move_x_z, Vector3.up);
            player_coordinates.rotation = Quaternion.RotateTowards(player_coordinates.rotation, Rotation, RotationSpeed * Time.deltaTime);
        }
    }

    public void GoodMoveVersion()
    {
        float x = Input.GetAxisRaw("Vertical");
        float z = -Input.GetAxisRaw("Horizontal");

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

        Vector3 gravity = Vector3.zero;
        if (characterController.isGrounded)
        {
            gravity.y = -2f;
        }
        else
        {
            gravity.y -= PlayerMovement.Gravity * -4f * Time.deltaTime;
        }
        characterController.Move(gravity);

        if (move_x_z != Vector3.zero)
        {
            float RotationSpeed = 720;
            Quaternion Rotation = Quaternion.LookRotation(move_x_z, Vector3.up);
            player_coordinates.rotation = Quaternion.RotateTowards(player_coordinates.rotation, Rotation, RotationSpeed * Time.deltaTime);
        }
    }

    public void ShitMoveVersion()
    {
        float x = Input.GetAxisRaw("Vertical");
        float z = -Input.GetAxisRaw("Horizontal");

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

        Vector3 gravity = Vector3.zero;
        if (characterController.isGrounded)
        {
            gravity.y = -2f;
        } else
        {
            gravity.y -= PlayerMovement.Gravity * -4f * Time.deltaTime;
        }
        characterController.Move(gravity);

        if (move_x_z != Vector3.zero)
        {
            float RotationSpeed = 720;
            Quaternion Rotation = Quaternion.LookRotation(move_x_z, Vector3.up);
            player_coordinates.rotation = Quaternion.RotateTowards(player_coordinates.rotation, Rotation, RotationSpeed * Time.deltaTime);
        }
    }
    public void TakeKnockback(float power, Vector3 direction){
        Debug.LogError("Knock");
        _impact += direction * power / _mass;
    }
}
