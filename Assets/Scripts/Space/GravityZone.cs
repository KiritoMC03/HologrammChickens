using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class GravityZone : MonoBehaviour
{
    internal HashSet<Rigidbody> AffectedBodies { get; set; } = new HashSet<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody != null)
        {
            AffectedBodies.Add(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            AffectedBodies.Remove(other.attachedRigidbody);
        }
    }
}
