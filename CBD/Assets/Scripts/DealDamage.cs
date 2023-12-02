using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private bool canHit;

    public CEOBehaviour CEO;

    public float CooldownDuration = 1.0f;

    public Transform CEODistance;

    public float minDisntance;

    void Start()
    {
        canHit = true;
    }

    void Update()
    {
        CheckHit();
        
    }

    void CheckHit()
    {
        float dist = Vector3.Distance(CEODistance.position, transform.position);
        //Debug.Log(dist);

        if (canHit && (dist <= minDisntance))
        {
            if (Input.GetMouseButtonDown(0))
            {
                CEO.TakeDamage();
                StartCoroutine(StartCooldown());
            }
        }
        
    }

    public IEnumerator StartCooldown()
    {
        canHit = false;

        yield return new WaitForSeconds(CooldownDuration);

        canHit = true;
    }

}
