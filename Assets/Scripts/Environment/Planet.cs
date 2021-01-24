using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Planet : MonoBehaviour
{
    private HashSet<Rigidbody> _affectedBodies = new HashSet<Rigidbody>();

    private Transform _transform;
    private Rigidbody _rigidbody;

    private Vector3 _toPlanet = Vector3.zero;

    void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        foreach (var body in _affectedBodies)
        {
            _toPlanet = _transform.position - body.position;

            float distance = _toPlanet.magnitude;
            float strength = body.mass * _rigidbody.mass / distance;

            body.AddForce(_toPlanet.normalized * strength);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            Debug.Log(other);
            _affectedBodies.Add(other.attachedRigidbody);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            _affectedBodies.Remove(other.attachedRigidbody);
        }
    }
}
