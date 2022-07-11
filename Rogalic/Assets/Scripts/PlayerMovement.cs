
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;

    [SerializeField] private CharacterController characterController;

    [SerializeField] private float Speed = 10f;
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private float Gravity = -9.81f;
    


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

        Vector3 move_x_z = transform.right * x + transform.forward * y;

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
    }
}
