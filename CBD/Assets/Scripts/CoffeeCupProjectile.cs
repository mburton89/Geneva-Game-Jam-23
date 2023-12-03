using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCupProjectile : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 velocity = transform.forward * 30f + transform.up * 2;

        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}