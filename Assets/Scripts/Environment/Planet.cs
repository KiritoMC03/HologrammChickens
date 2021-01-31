using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Planet : MonoBehaviour
{
    internal HashSet<Rigidbody> affectedBodies = new HashSet<Rigidbody>();

    private Transform _transform;
    private Rigidbody _rigidbody;
    private Vector3 _toPlanet = Vector3.zero;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        foreach (var body in affectedBodies)
        {
            _toPlanet = _transform.position - body.position;

            float distance = _toPlanet.magnitude;
            float strength = 10 * body.mass * _rigidbody.mass / distance;

            body.AddForce(_toPlanet.normalized * strength);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectedBodies.Add(other.attachedRigidbody);
        }
    }
}
