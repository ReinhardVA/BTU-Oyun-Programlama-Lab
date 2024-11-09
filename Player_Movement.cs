using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacther : MonoBehaviour
{
    public CharacterController controller;
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPosition;
    public float speed = 12f;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    private Vector3 _velocity;
    private bool _isGrounded;
    
    
    void Update()
    {
        GroundedCheck();
        PlayerMovement();
        ApplyGravity();
        // RaycastHit hitInfo;
        // if(Physics.Raycast(transform.position, transform.forward, out hitInfo)){

        // }
    }

    private void ApplyGravity(){
        IsPlayerGrounded();
        PlayerJumping();
        PlayerFalling();
    }
    private void IsPlayerGrounded()
    {
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
    }
    private void PlayerJumping()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * (-2f) * gravity);
        }
    }

    private void PlayerFalling()
    {
        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(speed * Time.deltaTime * move);
    }

    private void GroundedCheck()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
