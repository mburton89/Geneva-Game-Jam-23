using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEOBehaviour : MonoBehaviour
{
    // Main variables
    public float hp;
    public float moveSpeed;
    public BossBar GreenHP;

    // Unity variables
    //Rigidbody rb;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //hp = 100f;
        //moveSpeed = 4f;

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

    public void TakeDamage()
    {
        Debug.Log(hp);
        if (hp > 0)
        {
            hp = hp - 1;
        }
        else
        {
            hp = 0;
            Destroy(gameObject);
        }
        GreenHP.ChangeHP(hp);

    }
}
