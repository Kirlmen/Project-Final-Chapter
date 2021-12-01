using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Animator animatorX;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }


    private void Start()
    {
        animatorX = GetComponent<Animator>();
    }

    public void TakeDamage(float hitDamage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= hitDamage;
        Debug.Log(hitPoints);

        if (hitPoints <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) { return; }
        animatorX.SetTrigger("Died");
        isDead = true;
    }
}
