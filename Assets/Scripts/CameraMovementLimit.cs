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

        _tempPosition.x = ClampAxis(_transform.position.x, minimum.x, maximum.x);
        _tempPosition.y = ClampAxis(_transform.position.y, minimum.y, maximum.y);
        _tempPosition.z = ClampAxis(_transform.position.z, minimum.z, maximum.z);

        _transform.position = _tempPosition;
    }

    private float ClampAxis(float position, float minimum, float maximum)
    {
        if (position > maximum || position < minimum)
        {
            return Mathf.Clamp(position, minimum, maximum);
        }

        return position;
    }
}
