using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageAI : MonoBehaviour
{
    [SerializeField] Transform target;
    
    float DistanceToTarget = Mathf.Infinity;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTarget = Vector3.Distance(target.position, transform.position);
        if (DistanceToTarget <= navMeshAgent.stoppingDistance)
        {
            //Player.getComponent<RescueHandler>.HandleWin();
            //target.GetComponentInChildren<RescueHandler>().HandleWin();
            target.GetComponent<RescueHandler>().HandleWin();
            

        }
    }
}
