using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float Damage = 30f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit Hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out Hit, range))
        {
            Debug.Log("I did hit " + Hit.transform.name);
            EnemyHealth target = Hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
                return;
            target.TakeDamage(Damage);
        }
        else
            return;
        
    }
}
