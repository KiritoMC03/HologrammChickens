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
    Vector3 tempGravityVelocity = Vector3.zero;

    void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        //tempGravityVelocity = new Vector3(0, -_rigidbody.velocity.y, 0);

        StartCoroutine(GenerateMoveVector());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("GetMouseButtonDown");
            _rigidbody.velocity = _transform.up * 20;
        }
    }

    private void FixedUpdate()
    {
        ChangeVelocity();
        ChangeAngularVelocity();
    }

    private IEnumerator GenerateMoveVector()
    {
        var rand = UnityEngine.Random.Range(-1f, 1f);

        while (true)
        {
            forward = _transform.forward * rand;
            right = _transform.right * rand;

            yield return new WaitForSeconds(5);
        }
    }

    private void ChangeVelocity()
    {
        var temp = _rigidbody.velocity;
        temp.x = ((right + forward) * _moveSpeed).x;
        temp.z = ((right + forward) * _moveSpeed).z;
        _rigidbody.velocity = temp;
    }

    private void ChangeAngularVelocity()
    {
        var temp = _rigidbody.angularVelocity;
        temp.x = ((right + forward) * _moveSpeed).x;
        temp.z = ((right + forward) * _moveSpeed).z;
        _rigidbody.angularVelocity = temp;
    }
}
