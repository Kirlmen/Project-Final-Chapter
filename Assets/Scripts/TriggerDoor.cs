using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] Animator m_Animator;
    [SerializeField] private TextMeshProUGUI lockedText;

    private void Awake()
    {
        lockedText.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerMovementScript>().hasKey)
            {
                m_Animator.SetTrigger("DoorTrigger");
            }
            else
            {
                lockedText.enabled = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerMovementScript>().hasKey == false)
            {
                lockedText.enabled = false;
            }
        }
    }
}
