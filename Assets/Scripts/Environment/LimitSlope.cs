using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitSlope : MonoBehaviour
{
    [SerializeField] internal Transform targetPlanet;

    private Transform _transform;
    private Quaternion _rotation;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _rotation = Quaternion.FromToRotation(-_transform.up, targetPlanet.position - _transform.position);
        _transform.rotation = _rotation * _transform.rotation;
    }
}