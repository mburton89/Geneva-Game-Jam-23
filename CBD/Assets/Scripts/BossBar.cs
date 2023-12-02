using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBar : MonoBehaviour
{
    public GameObject GreenHP;

    public float maxHP;

    public void ChangeHP(float hp)
    {
        Debug.Log(hp / maxHP);
        if((hp/maxHP) >0.2)
        {
            GreenHP.gameObject.transform.localScale = new Vector3((hp / maxHP), (float)1.1, (float)1.1);
        }
        else
            GreenHP.gameObject.transform.localScale = new Vector3((float)0.05, (float)1.1, (float)1.1);

    }
}
