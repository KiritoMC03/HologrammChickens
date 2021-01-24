using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitSlope : MonoBehaviour
{
    [SerializeField] internal Transform targetPlanet;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.FromToRotation(-_transform.up, targetPlanet.position - _transform.position);
        _transform.rotation = rotation * _transform.rotation;
    }
}
