using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    [SerializeField] private float keyTurnSpeed = 1f;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovementScript>().hasKey = true;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, keyTurnSpeed);
    }
}