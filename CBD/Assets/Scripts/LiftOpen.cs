using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftOpen : MonoBehaviour
{
    public Transform Player;

    public Transform BackWall;

    public GameObject DoorR;
    public GameObject DoorL;
    bool openDelay = true;
    public float CooldownDuration = 1.0f;

    private int counter = 0;
    private int counter2 = 0;
    public int DistFromFloor;

    bool isBossDead = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.position, BackWall.position);

        if ((counter<9) && !isBossDead)
        {
            
            OpenDoors();
            Debug.Log(counter);
        }
            

        if((dist > DistFromFloor) && (counter>=9) && (counter<17) && !isBossDead)
        {
            CloseDoors();
            Debug.Log(counter);
        }

        if ((counter == 17) && isBossDead)
            counter = 0;

        if(isBossDead && (counter<8) && (dist > DistFromFloor))
        {
         
            OpenDoors();
            Debug.Log(counter);
        }

        if ((dist < (DistFromFloor-1)) && (counter >= 8) && (counter < 17) && isBossDead)
        {
            CloseDoors();
            Debug.Log(counter);

        }
    }

    public void OpenDoors()
    {
        if(openDelay)
        {
            DoorR.transform.position += new Vector3(0, 0, (float)-0.5);
            DoorL.transform.position += new Vector3(0, 0, (float) 0.5);
            StartCoroutine(StartCooldown());
        }
            
    }

    public IEnumerator StartCooldown()
    {
        openDelay = false;

        yield return new WaitForSeconds(CooldownDuration);

        openDelay = true;
        counter++;
    }

    void CloseDoors()
    {
        if (openDelay)
        {
            DoorR.transform.position += new Vector3(0, 0, (float)0.5);
            DoorL.transform.position += new Vector3(0, 0, (float)-0.5);
            StartCoroutine(StartCooldown());
        }
    }

    public void BossDead()
    {
        isBossDead = true;
    }
}
