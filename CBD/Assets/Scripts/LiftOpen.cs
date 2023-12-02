using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftOpen : MonoBehaviour
{
    public Transform Player;

    public Transform Floor;

    public GameObject DoorR;
    public GameObject DoorL;
    bool openDelay = true;
    public float CooldownDuration = 1.0f;

    private int counter = 0;
    public int DistFromFloor;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.position, Floor.position);

        if (counter<9)
            OpenDoors();
        if((dist > DistFromFloor) && (counter>=9) && (counter<18))
        {
            CloseDoors();
        }
    }

    void OpenDoors()
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
}
