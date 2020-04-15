using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    bool isDead = false;
    [SerializeField] float HitPoints = 100f;
    public bool IsDead()
    {
        return isDead;

    }
    public void TakeDamage(float PDamage)
    {
        BroadcastMessage("OnDamageTaken");
        float TempHP = HitPoints - PDamage;
        if (!(TempHP <= 0))
            HitPoints = TempHP;
        else
        {
            HitPoints = 0;
            //Destroy(gameObject);
            if (isDead) return;
            isDead = true;
            BroadcastMessage("KillEnemy");
            
        }
    }
}
