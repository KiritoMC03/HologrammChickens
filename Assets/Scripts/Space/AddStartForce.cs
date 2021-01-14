using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AddStartForce : MonoBehaviour
{
    [SerializeField] private Vector3 _force;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(_force);
    }
}
