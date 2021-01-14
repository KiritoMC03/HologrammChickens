using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlanetGravity : MonoBehaviour
{
    [SerializeField] private GravityZone _gravityZone;
    private Rigidbody _rigidbody;
    private const float G = 9.8f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_gravityZone == null)
        {
            throw new Exception("GravityZone не установлен.");
        }
        else
        {
            _gravityZone = _gravityZone.GetComponent<GravityZone>();
        }

        if(_rigidbody != null)
        {
            _rigidbody.useGravity = false;
        }
    }

    void FixedUpdate()
    {
        CheckAffectedBodies(_gravityZone.AffectedBodies);
    }

    private void CheckAffectedBodies(HashSet<Rigidbody> affectedBodies)
    {
        foreach (Rigidbody body in affectedBodies)
        {
            var toBody = (transform.position - body.position);
            var direction = toBody.normalized;
            var distance = toBody.magnitude;
            var force = G * body.mass * _rigidbody.mass / distance * distance;

            body.AddForce(direction * force);
        }
    }
}
