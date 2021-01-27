using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateFieldOfGravity : MonoBehaviour
{
    [SerializeField] private float normalWeight = 1f;
    [SerializeField] private float ultimateWeight = 1000f;

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.mass = ultimateWeight;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.mass = normalWeight;
        }
    }
}
