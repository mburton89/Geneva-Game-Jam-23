using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float hp = 100;
    public Vector3 spawn_point;
    private bool isDamaged;
    private float damageCooldown;

    // Start is called before the first frame update
    void Start()
    {
        damageCooldown = 3;
        isDamaged = true;
        spawn_point = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves an object tagged as "Ground"
        if (!isDamaged && collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("CoffeeCup"))
        {
            hp -= 5;
        }

        if (hp < 0)
        {
            transform.position = spawn_point;
            hp = 100;
        }

        DamageCooldown();
    }

    IEnumerator DamageCooldown()
    {
        isDamaged = true;
        yield return new WaitForSeconds(damageCooldown);
        isDamaged = false;
    }
}
