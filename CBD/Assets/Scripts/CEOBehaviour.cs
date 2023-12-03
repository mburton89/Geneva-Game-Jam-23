using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEOBehaviour : MonoBehaviour
{
    // Main variables
    public float hp;
    public float moveSpeed;
    public float maxSpeed;
    public float jumpForce;
    public float attackDistance;
    public bool isGrounded;

    public LiftOpen Lift;
    // Unity variables
    public Transform player;
    Rigidbody rb;
    public BossBar GreenHP;

    // Start is called before the first frame update
    void Start()
    {
        /*hp = 100f;
        moveSpeed = 2f;
        jumpForce = 0.5f;
        maxSpeed = 5f;
        attackDistance = 10f;*/
        isGrounded = false;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();

        if (IsCloseToPlayer() && isGrounded)
        {
            Jump();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter");
        // Check if the collision involves an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("CEO is colliding with the plane!");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Reset the collision status when the CEO is not colliding with the plane anymore
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("CEO is not colliding with the plane!");
        }
    }

    Vector3 HorizontalDirection(Vector3 pointA, Vector3 pointB)
    {
        pointA.y = 0;
        pointB.y = 0;

        return (pointB - pointA).normalized;
    }

    float HorizontalDistance(Vector3 pointA, Vector3 pointB)
    {
        pointA.y = 0;
        pointB.y = 0;

        return Vector3.Distance(pointA, pointB);
    }

    void MoveTowardsPlayer()
    {
        // Move towards the player
        Vector3 direction = HorizontalDirection(transform.position, player.position);
        transform.LookAt(player);
        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.AddForce(direction * moveSpeed);
        } 
    }

    bool IsCloseToPlayer()
    {
        return HorizontalDistance(transform.position, player.position) <= attackDistance;
    }

    void Jump()
    {
        if (isGrounded && Mathf.Approximately(rb.velocity.y, 0f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Attack()
    {

    }

    public void TakeDamage()
    {
        Debug.Log(hp);
        if (hp > 1)
        {
            hp = hp - 1;
        }
        else
        {
            hp = 0;
            Destroy(gameObject);
            Lift.BossDead();
        }
        GreenHP.ChangeHP(hp);
    }
}
