using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CreaturerMotor : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;

    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 forward = Vector3.zero;
    private Vector3 right = Vector3.zero;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        StartCoroutine(GenerateMoveVector());
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(((right + forward) * _moveSpeed));
    }

    private IEnumerator GenerateMoveVector()
    {
        while (true)
        {
            forward = _transform.forward * UnityEngine.Random.Range(-1f, 1f);
            right = _transform.right * UnityEngine.Random.Range(-1f, 1f);

            yield return new WaitForSeconds(5);
        }
    }
}
