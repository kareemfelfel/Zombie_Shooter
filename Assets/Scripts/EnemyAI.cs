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
    NavMeshAgent navMeshAgent;
    float DistanceToTarget = Mathf.Infinity;
    bool IsProvoked = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log(name + " has seeked and is destroying " + target.name);
    }

    private void ChaseTarget()
    {
        Debug.Log(name + " is chasing " + target.name);
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, .75f);
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
    }
}
