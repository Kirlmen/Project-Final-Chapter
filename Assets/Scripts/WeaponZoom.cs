using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    float fieldOfView;
    RigidbodyFirstPersonController firstPersonController;

    bool zoomedInToggle = false;
    void Start()
    {
        fieldOfView = 60f;
        firstPersonController = GetComponent<RigidbodyFirstPersonController>();
    }


    void Update()
    {
        Camera.main.fieldOfView = fieldOfView;

        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                firstPersonController.mouseLook.XSensitivity = 1f;
                firstPersonController.mouseLook.YSensitivity = 1f;
                zoomedInToggle = true;
                fieldOfView = 30f;
            }
            else
            {
                zoomedInToggle = false;
                fieldOfView = 60f;
                firstPersonController.mouseLook.XSensitivity = 2f;
                firstPersonController.mouseLook.YSensitivity = 2f;
            }

        }
    }

}


