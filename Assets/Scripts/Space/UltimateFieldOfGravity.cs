using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateFieldOfGravity : MonoBehaviour
{
    [SerializeField] private float _normalWeight = 1f;
    [SerializeField] private float _ultimateWeight = 1000f;

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.mass = _ultimateWeight;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.mass = _normalWeight;
        }
    }
}
