using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(OrbitRenderer))]
public class OrbitQuality : MonoBehaviour
{
    [SerializeField] private bool _renderEveryFrame;
    [SerializeField] private float _baseLineWidth = 0.15f;
    [SerializeField] private float _normalRenderDistance = 200f;
    [SerializeField] private float _lineScale = 2f;
    [SerializeField] private Camera _spaceCamera;

    private OrbitRenderer _orbitRenderer;
    private LineRenderer _lineRenderer;
    private Coroutine _renderEveryFrameRoutine;

    private SpaceCameraMovement _spaceCameraMovement;
    private SpaceCameraRange _spaceCameraRange;

    private void Awake()
    {
        _orbitRenderer = GetComponent<OrbitRenderer>();
        _lineRenderer = GetComponent<LineRenderer>();
        _spaceCameraMovement = _spaceCamera.GetComponent<SpaceCameraMovement>();
        _spaceCameraRange = _spaceCamera.GetComponent<SpaceCameraRange>();

        _spaceCameraMovement.Moved.AddListener(new UnityAction(ChangeWidth));
    }

    private void Start()
    {
        if (_renderEveryFrame)
        {
            _renderEveryFrameRoutine = StartCoroutine(_orbitRenderer.RenderLine(_renderEveryFrame));
        }
    }
    /*
    private void OnEnable()
    {
        _renderEveryFrameRoutine = StartCoroutine(_orbitRenderer.RenderLine(_renderEveryFrame));
    }

    private void OnDisable()
    {
        StopCoroutine(_renderEveryFrameRoutine);
    }*/

    public void ChangeWidth()
    {
        _lineRenderer.widthMultiplier = _spaceCameraRange.GetDistanceToSun() * _baseLineWidth * _lineScale / _normalRenderDistance;
    }
}
