using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FPSController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;



    public float speed = 10f;
    public float jumpForce = 5f;


    public bool shoot;



    public Transform cameraTransform;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    public void OnFire(InputValue value){
        shoot = value.isPressed;
    }
    private void FixedUpdate()
    {
        Vector3 moveDirection = (cameraTransform.forward * movementY + cameraTransform.right * movementX).normalized;
        moveDirection.y = 0;

        rb.AddForce(moveDirection * speed, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

    }
}
