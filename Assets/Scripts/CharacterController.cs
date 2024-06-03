using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    public float moveSpeed = 5f;
    public float rotationSpeed = 700f;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 moveVector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalMove, 0, verticalMove).normalized;

        if (moveDirection != Vector3.zero) {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        } 
    }

    void FixedUpdate()
    {
            rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
    }
}
