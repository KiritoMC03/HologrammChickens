using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class TerrainHandler : MonoBehaviour
{
    private Terrain _terrain;
    private Transform _transform;

    internal float Width { get; private set; }
    internal float Length { get; private set; }
    internal float WidthOffset { get; private set; }
    internal float LengthOffset { get; private set; }

    void Start()
    {
        _terrain = GetComponent<Terrain>();

        Width = _terrain.terrainData.size.x;
        Length = _terrain.terrainData.size.z;

        WidthOffset = 1; //_terrainWidth / 100 * 15;
        LengthOffset = 1; // _terrainLength / 100 * 15;
    }
}
