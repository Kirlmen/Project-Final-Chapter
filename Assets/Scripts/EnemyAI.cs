using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float aggroRange = 5f;
    NavMeshAgent navMeshAgent;
    Animator animatorX;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animatorX = GetComponent<Animator>();
    }

    void Update()
    {
        EnemyAggro();
    }

    private void EnemyAggro()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }

        else if (distanceToTarget <= aggroRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if (navMeshAgent.stoppingDistance <= distanceToTarget)
        {
            ChaseTarget();
        }
        if (navMeshAgent.stoppingDistance >= distanceToTarget)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        animatorX.SetBool("Attack", false);
        animatorX.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position); //chase the target

    }

    private void AttackTarget()
    {
        animatorX.SetBool("Attack", true);
        Debug.Log(name + "attacking the target!");
    }

    private void OnDrawGizmosSelected() //shows the aggro-range in editor mode
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
