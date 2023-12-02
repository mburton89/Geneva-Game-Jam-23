using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float movementSpeed;
    //public GameObject player;

    public Transform playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;

    void Update()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Mover();
        LookAtMouse();
    }

    void Mover()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed); //move forward
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * movementSpeed); //move backwards
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed); //move left
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed); //move right
        }

    }

    void LookAtMouse()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
