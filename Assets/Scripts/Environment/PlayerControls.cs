using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    private Rigidbody _rigidbody;
    private Transform _transform;

    void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 forward = _transform.forward * Input.GetAxis("Vertical");
        Vector3 right = _transform.right * Input.GetAxis("Horizontal");

        //_rigidbody.AddForce((forward + right) * Time.fixedDeltaTime * 200);
        Vector3 gravityVelocity = new Vector3(0, -_rigidbody.velocity.y, 0);

        _rigidbody.velocity = ((right + forward) * _moveSpeed) + gravityVelocity;
        _rigidbody.angularVelocity = (right + forward) * _moveSpeed;
    }
}
