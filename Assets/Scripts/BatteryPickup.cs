using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] float defaultAngle = 49f;
    [SerializeField] float defaultIntensity = 2.2f;

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(defaultAngle);
            other.GetComponentInChildren<FlashlightSystem>().RestoreLightIntensity(defaultIntensity);
            Destroy(gameObject);
        }
    }


}
