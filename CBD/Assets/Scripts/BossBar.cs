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
        GreenHP.gameObject.transform.localScale = new Vector3((hp/maxHP), (float)1.1, (float)1.1);
    }
}
