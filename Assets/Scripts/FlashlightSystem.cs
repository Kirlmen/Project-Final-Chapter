using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;


    private void Start()
    {
        myLight = GetComponent<Light>();
    }


    private void Update()
    {
        DecraseLightAngle();
        DecraseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float restoreAmount)
    {
        myLight.intensity = restoreAmount;
    }

    private void DecraseLightIntensity()
    {

        myLight.intensity -= lightDecay * Time.deltaTime;

    }

    private void DecraseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else { myLight.spotAngle -= angleDecay * Time.deltaTime; }
    }
}
