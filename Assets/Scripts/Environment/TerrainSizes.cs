using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
[RequireComponent(typeof(BoxCollider))]
public class TerrainSizes : MonoBehaviour
{
    internal Vector3 worldOffset;

    [SerializeField] internal float width;
    [SerializeField] internal float length;
    [SerializeField] internal float underlyingColliderDepth = 5f;
    [Header("For NavMesh")]
    [SerializeField] internal float widthOffset;
    [SerializeField] internal float lengthOffset;

    private Terrain _terrain;
    private Transform _transform;
    private BoxCollider _boxCollider;

    void Awake()
    {
        _transform = transform;
        _terrain = GetComponent<Terrain>();
        _boxCollider = GetComponent<BoxCollider>();
        worldOffset = _transform.position;
        widthOffset = Mathf.Abs(widthOffset);
        lengthOffset = Mathf.Abs(lengthOffset);

        var tempTerrainDataSize = _terrain.terrainData.size;
        tempTerrainDataSize.x = width;
        tempTerrainDataSize.z = length;
        _terrain.terrainData.size = tempTerrainDataSize;

        var tempBoxColliderSize = _boxCollider.size;
        tempBoxColliderSize.x = width;
        tempBoxColliderSize.z = length;
        tempBoxColliderSize.y = underlyingColliderDepth;
        _boxCollider.size = tempBoxColliderSize;

        var tempBoxColliderCenter = _boxCollider.center;
        tempBoxColliderCenter.x = width / 2;
        tempBoxColliderCenter.z = length / 2;
        tempBoxColliderCenter.y = -underlyingColliderDepth / 2;
        _boxCollider.center = tempBoxColliderCenter;
    }
}
