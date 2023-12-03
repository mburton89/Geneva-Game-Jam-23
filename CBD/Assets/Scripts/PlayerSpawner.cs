using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public float hp = 100;
    private GameObject playerPrefab;
    private Transform spawnPoint;
    private bool isDamaged;
    private float damageCooldown;

    // Start is called before the first frame update
    void Start()
    {
        playerPrefab = GameObject.FindGameObjectWithTag("Player").transform.gameObject;
        spawnPoint = playerPrefab.transform;
        isDamaged = false;
        damageCooldown = 4;

        SpawnPlayer();
}

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayer()
    {
        // Instantiate or activate the player prefab at the spawn point
        GameObject playerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

        Camera camera = playerPrefab.GetComponentInChildren<Camera>();

        // Optionally, you can set the player and camera instances as children of the spawner
        playerInstance.transform.parent = transform;
        camera.transform.parent = playerInstance.transform;
    }

    void OnCollisionStay(Collision collision)
    {
        // Check if the collision involves an object tagged as "Ground"
        if (!isDamaged && collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("CoffeeCup"))
        {
            hp -= 10;
        }

        if (hp < 0)
        {
            SpawnPlayer();
            Destroy(gameObject);
            
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
