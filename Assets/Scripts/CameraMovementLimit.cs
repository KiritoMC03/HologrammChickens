using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraMovement))]
public class CameraMovementLimit : MonoBehaviour
{
    [SerializeField] private Vector3 maximum = Vector3.zero;
    [SerializeField] private Vector3 minimum = Vector3.zero;

    private Transform _transform;
    private CameraMovement _cameraMovement;
    private Vector3 _tempPosition = Vector3.zero;

    private void Awake()
    {
        _transform = transform;
        _cameraMovement = GetComponent<CameraMovement>();
        _cameraMovement.Moved.AddListener(Check);
    }

    public void Check()
    {
        if(_cameraMovement == null)
        {
            throw new Exception("Отсутствует компонент CameraMovement.");
        }

        _tempPosition = _transform.position;

        if (_transform.position.x > maximum.x || _transform.position.x < minimum.x)
        {
            _tempPosition.x = Mathf.Clamp(_transform.position.x, minimum.x, maximum.x);
        }
        if (_transform.position.y > maximum.y || _transform.position.y < minimum.y)
        {
            _tempPosition.y = Mathf.Clamp(_transform.position.y, minimum.y, maximum.y);
        }
        if (_transform.position.z < minimum.z || _transform.position.z > maximum.z)
        {
            _tempPosition.z = Mathf.Clamp(_transform.position.z, minimum.z, maximum.z);
        }

        _transform.position = _tempPosition;
    }
}
