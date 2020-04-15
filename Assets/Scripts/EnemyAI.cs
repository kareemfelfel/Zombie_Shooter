using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    // how close is the enemy so I can start chasing him
    [SerializeField] float ChaseRange = 10f;
    [SerializeField] float TurnSpeed = 8;
    NavMeshAgent navMeshAgent;
    float DistanceToTarget = Mathf.Infinity;
    bool IsProvoked = false;
    EnemyHealth Health;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        
        DistanceToTarget = Vector3.Distance(target.position, transform.position);
        if (IsProvoked)
        {
            EngageTarget();
        }
        else if (DistanceToTarget <= ChaseRange)
        {
            IsProvoked = true;
        }
        
    }

    private void EngageTarget()
    {
        FaceTarget();
        
        // if there is still a distance between enemy and target
        if(DistanceToTarget>navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        //If we are at the place with target
        if(DistanceToTarget<= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
            
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
       
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, .75f);
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*TurnSpeed);
    }
    public void OnDamageTaken()
    {
        IsProvoked = true;
    }
    public void KillEnemy()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().ResetTrigger("move");
        GetComponent<Animator>().SetTrigger("die");
        IsProvoked = false;
    }
    
}
