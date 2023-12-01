using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody myBody;
    Camera m_camera;



    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        m_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();

    }

    void Mover()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement);

        // Don't keep calling Camera.main




        Camera m_camera;

        /*if (Input.GetKeyDown(KeyCode.W))
        {
            //transform.position = transform.position + new Vector3(movementSpeed*Time.deltaTime) ;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //myBody.velocity = -transform.forward * movementSpeed;
        }*/

    }
}
