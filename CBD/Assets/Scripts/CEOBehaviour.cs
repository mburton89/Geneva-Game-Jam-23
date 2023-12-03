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
    public float rangeAttackDistance;
    public bool isGrounded;
    public bool canAttack;
    public float attackCooldown;

    public LiftOpen Lift;
    // Unity variables
    public Transform player;
    Rigidbody rb;
    public BossBar GreenHP;
    public GameObject coffeeCupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100f;
        moveSpeed = 2f;
        jumpForce = .3f;
        maxSpeed = 5f;
        attackDistance = 10f;
        rangeAttackDistance = 15f;
        isGrounded = false;
        canAttack = true;
        attackCooldown = 5f;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        coffeeCupPrefab = GameObject.FindGameObjectWithTag("CoffeeCup");
        Debug.Log(coffeeCupPrefab);

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        InvokeRepeating("CoffeeCupProjectile", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();

        if (canAttack)
        {
            Attack();
            StartCoroutine(AttackCooldown());
        }

        if (IsCloseToPlayer(attackDistance) && isGrounded)
        {
            Jump();
        }

        Debug.Log(isGrounded);
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

    bool IsCloseToPlayer(float distance)
    {
        return HorizontalDistance(transform.position, player.position) <= distance;
    }

    void Jump()
    {
        if (isGrounded && Mathf.Approximately(rb.velocity.y, 0f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void ThrowCoffeeCup()
    {
        GameObject coffeeCup = Instantiate(coffeeCupPrefab, transform.position, Quaternion.LookRotation(player.position - transform.position));

        Destroy(coffeeCup, 5);
    }
    void Attack()
    {
        if (canAttack && IsCloseToPlayer(rangeAttackDistance))
        {
            ThrowCoffeeCup();
        }
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
