using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
[RequireComponent(typeof(BoxCollider))]
public class TerrainSizes : MonoBehaviour
{
    internal Vector3 worldOffset;

    private Terrain _terrain;
    private Transform _transform;
    private BoxCollider _boxCollider;

    [SerializeField] internal float width;
    [SerializeField] internal float length;
    [SerializeField] private float _groundSafeZone = 5f;
    [Header("For NavMesh")]
    [SerializeField] internal float widthOffset;
    [SerializeField] internal float lengthOffset;

    void Awake()
    {
        _transform = transform;
        _terrain = GetComponent<Terrain>();
        _boxCollider = GetComponent<BoxCollider>();

        widthOffset = Mathf.Abs(widthOffset);
        lengthOffset = Mathf.Abs(lengthOffset);

        var tempTerrainDataSize = _terrain.terrainData.size;
        tempTerrainDataSize.x = width;
        tempTerrainDataSize.z = length;
        _terrain.terrainData.size = tempTerrainDataSize;

        var tempBoxColliderSize = _boxCollider.size;
        tempBoxColliderSize.x = width;
        tempBoxColliderSize.z = length;
        tempBoxColliderSize.y = _groundSafeZone;
        _boxCollider.size = tempBoxColliderSize;

        var tempBoxColliderCenter = _boxCollider.center;
        tempBoxColliderCenter.x = width / 2;
        tempBoxColliderCenter.z = length / 2;
        tempBoxColliderCenter.y = -_groundSafeZone / 2;
        _boxCollider.center = tempBoxColliderCenter;
    }

    private void Start()
    {
        worldOffset = _transform.position;
        Debug.Log(worldOffset);
    }
}
