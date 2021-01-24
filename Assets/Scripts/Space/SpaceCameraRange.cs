using UnityEngine;

[RequireComponent(typeof(SpaceCameraMovement))]
public class SpaceCameraRange : MonoBehaviour
{
    internal float distanceToSun;

    [SerializeField] private Transform _sun;

    private Transform _transform;
    private SpaceCameraMovement _spaceCameraHandler;

    private void Awake()
    {
        _transform = transform;
        _sun = _sun.transform;
        _spaceCameraHandler = GetComponent<SpaceCameraMovement>();

        GetDistanceToSun();
    }

    internal float GetDistanceToSun()
    {
        distanceToSun = Mathf.Abs((_sun.position - _transform.position).y);

        return distanceToSun;
    }

}
