using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    /* I tried to do the character controller, but it doesn't work yet. */
    // Main variables
    public float moveSpeed;
    public float rotationSpeed;
    public float direction;

    // Unity variables
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        rotationSpeed = 5f;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calculate the movement direction
        Vector3 direction = forward * vertical + right * horizontal;
        direction.Normalize();

        /*
        // Move the character
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 currentRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(currentRotation.x, currentRotation.y + mouseX * rotationSpeed, currentRotation.z));*

        characterController.transform.Translate(direction * moveSpeed * Time.deltaTime);*/

    }
}