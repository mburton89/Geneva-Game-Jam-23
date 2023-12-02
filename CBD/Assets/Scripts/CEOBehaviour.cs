using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEOBehaviour : MonoBehaviour
{
    // Main variables
    public float hp;
    public float moveSpeed;

    // Unity variables
    //Rigidbody rb;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100f;
        moveSpeed = 4f;

        //rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Move towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
