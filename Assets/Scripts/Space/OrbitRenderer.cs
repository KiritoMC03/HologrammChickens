using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(OrbitMovement))]
public class OrbitRenderer : MonoBehaviour
{
    [Range(4, 100)]
    [SerializeField] private int _segments;
    [SerializeField] private bool _renderEveryFrame;
    [SerializeField] private float _baseLineWidth = 0.15f;
    [SerializeField] private float _baseCameraDistance = 200;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _sun;

    private Orbit _orbit;
    private LineRenderer _lineRenderer;
    private OrbitMovement _orbitMovement;
    private Coroutine _renderEveryFrameRoutine;
    private SpaceCameraMovement _spaceCameraHandler;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _orbitMovement = GetComponent<OrbitMovement>();
        _sun = _sun.transform;
        _camera = _camera.transform;
        _orbit = _orbitMovement.orbitPath;
        CalculateEllipse();

        _renderEveryFrameRoutine = StartCoroutine(RenderLine(_renderEveryFrame));

        if(_camera != null)
        {
            _spaceCameraHandler = _camera.GetComponent<SpaceCameraMovement>();
            _spaceCameraHandler.Moved.AddListener(new UnityAction(ChangeWidth));
        }
    }

    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[_segments + 1];

        for (int i = 0; i < _segments; i++)
        {
            Vector2 position2D = _orbit.Evaluate(i / (float)_segments);
            points[i] = new Vector3(position2D.x, 0f, position2D.y) + transform.position;
        }

        points[_segments] = points[0];

        _lineRenderer.positionCount = _segments + 1;
        _lineRenderer.SetPositions(points);
    }

    public void ChangeWidth()
    {
        Debug.Log("ChangeWidth");
        var offset = Mathf.Abs((_sun.position - _camera.position).magnitude);
        _lineRenderer.widthMultiplier = offset * _baseLineWidth / _baseCameraDistance;
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            CalculateEllipse();
        }
    }

    IEnumerator RenderLine(bool condition)
    {
        for(; ; )
        {
            if (condition)
            {
                CalculateEllipse();
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
