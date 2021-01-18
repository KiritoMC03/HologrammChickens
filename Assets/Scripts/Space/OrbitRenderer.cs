using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(OrbitMovement))]
public class OrbitRenderer : MonoBehaviour
{
    /*[SerializeField]*/ private Orbit _orbit;
    [Range(4, 100)]
    [SerializeField] private int _segments;
    [SerializeField] private bool _renderEveryFrame;
    private LineRenderer _lineRenderer;
    private OrbitMovement _orbitMovement;
    private Coroutine _renderEveryFrameRoutine;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _orbitMovement = GetComponent<OrbitMovement>();
        _orbit = _orbitMovement.orbitPath;
        CalculateEllipse();

        _renderEveryFrameRoutine = StartCoroutine(RenderLine(_renderEveryFrame));
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
