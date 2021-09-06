using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = .4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight = 3f;

    private Vector3 velocity;
    private float gravity = -9.8f;
    private bool isGrounded;

    // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log("isGrounded: " + isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
