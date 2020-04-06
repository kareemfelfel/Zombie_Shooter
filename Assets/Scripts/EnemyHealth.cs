using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float HitPoints = 100f;
    public void TakeDamage(float PDamage)
    {
        float TempHP = HitPoints - PDamage;
        if (!(TempHP <= 0))
            HitPoints = TempHP;
        else
        {
            HitPoints = 0;
            Destroy(gameObject);
        }
    }
}
