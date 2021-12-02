using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    float maxPlayerHealth = 100f;
    public float currentHealth;

    GameObject hurtEffect;

    EnemyAttack enemyAttack;
    DeathHandler deathHandler;
    GunInventory gunInventory;
    [SerializeField] private Image bloodImage = null;
    [SerializeField] private float hurtTimer = 1f;

    [Header("Heal Timer")]
    [SerializeField] private int regenRate = 1;
    private bool canRegen = false;
    [SerializeField] private float healCooldown = 3.0f;
    [SerializeField] private float maxHealCooldown = 3.0f;
    [SerializeField] private bool startCooldown = false;



    void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        deathHandler = GetComponent<DeathHandler>();
        currentHealth = maxPlayerHealth;
    }

    private void Update()
    {
        if (startCooldown)
        {
            healCooldown = -Time.deltaTime;
            if (healCooldown <= 0)
            {
                canRegen = true;
                startCooldown = false;
            }
        }

        if (canRegen)
        {
            if (currentHealth <= maxPlayerHealth - 0.01)
            {
                currentHealth += Time.deltaTime * regenRate;
                UpdateHealth();
            }
            else
            {
                currentHealth = maxPlayerHealth;
                healCooldown = maxHealCooldown;
                canRegen = false;
            }
        }
    }

    public void PlayerTakeDamage(float takeDamage)
    {
        currentHealth -= takeDamage;
        canRegen = false;
        StartCoroutine(HurtFlash());
        UpdateHealth();
        healCooldown = maxHealCooldown;
        startCooldown = true;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            gunInventory = GetComponent<GunInventory>();
            gunInventory.DeadMethod();
            deathHandler.HandleDeath();
        }
    }

    void UpdateHealth()
    {
        Color splatterAlpha = bloodImage.color;
        splatterAlpha.a = 1 - (currentHealth / maxPlayerHealth);
        bloodImage.color = splatterAlpha;
    }

    IEnumerator HurtFlash()
    {
        bloodImage.enabled = true;
        yield return new WaitForSeconds(hurtTimer);
        bloodImage.enabled = false;
    }

}
