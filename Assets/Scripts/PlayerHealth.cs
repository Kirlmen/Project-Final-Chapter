using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    float playerHealth = 100f;
    public float currentHealth;

    EnemyAttack enemyAttack;
    DeathHandler deathHandler;

    void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        deathHandler = GetComponent<DeathHandler>();
        currentHealth = playerHealth;
    }

    public void PlayerTakeDamage(float takeDamage)
    {
        currentHealth -= takeDamage;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            deathHandler.HandleDeath();
        }
    }

}
