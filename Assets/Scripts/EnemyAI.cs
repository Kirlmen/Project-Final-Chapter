using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float aggroRange = 5f;
    [SerializeField] float turnSpeed = 4f;
    NavMeshAgent navMeshAgent;
    Animator animatorX;
    EnemyHealth enemyHealth;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animatorX = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (enemyHealth.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        EnemyAggro();
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
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
        FaceTarget();
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
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); //halihazırda baktığı yer, playerın olduğu yer, timedeltatime * turnspeed;
    }


    private void OnDrawGizmosSelected() //shows the aggro-range in editor mode
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
