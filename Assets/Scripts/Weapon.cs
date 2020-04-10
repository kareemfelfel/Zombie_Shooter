using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float Damage = 30f;
    [SerializeField] ParticleSystem MuzzleFlash;
    [SerializeField] GameObject HitEffect;
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
        PlayMuzzleFlash();
        ProcessRaycast();

    }

    private void PlayMuzzleFlash()
    {
        MuzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit Hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out Hit, range))
        {
            CreateHitImpact(Hit);
            EnemyHealth target = Hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
                return;
            target.TakeDamage(Damage);
        }
        else
            return;
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject Impact = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(Impact, (float).1f);
    }
}
