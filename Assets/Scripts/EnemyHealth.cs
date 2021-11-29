using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;




    public void TakeDamage(float hitDamage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= hitDamage;
        Debug.Log(hitPoints);

        if (hitPoints <= 0f)
        {
            Destroy(gameObject);
        }
    }

}
