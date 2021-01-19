using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpaceCameraMovement : MonoBehaviour
{
    public UnityEvent Moved;

    private Transform _transform;
    private Vector3 _tempPosition;
    private Quaternion _tempRotation;

    private void Start()
    {
        _transform = transform;
        _tempPosition = _transform.position;
        _tempRotation = _transform.rotation;
    }

    private void Update()
    {
        if (_transform.position != _tempPosition || _transform.rotation != _tempRotation)
        {
            Debug.Log("Invoke");
            Moved.Invoke();
            _tempPosition = _transform.position;
        }
    }
}
