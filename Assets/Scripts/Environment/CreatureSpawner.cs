using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    internal HashSet<GameObject> spawnedCreatures = new HashSet<GameObject>();

    [SerializeField] private GameObject _creature;
    [SerializeField] private Transform _area;
    [SerializeField] private float _spread = 5f;
    [SerializeField] private uint _count = 3;
    [Range(0.1f, 5f)]
    [SerializeField] private float speed = 0.5f;

    private TerrainSizes _terrain;
    private Coroutine spawnerRoutine;

    void Start()
    {
        if (_creature == null)
        {
            throw new Exception("Поле Creature не установлено!");
        }
        if (_area == null)
        {
            throw new Exception("Поле Area не установлено!");
        }

        spawnerRoutine = StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        if (_area == null || _creature == null)
        {
            throw new Exception("Поле Creature или Area не установлено!");
        }

        for (int i = 0; i < _count; i++)
        {
            Instantiate(_creature, _area);
            yield return new WaitForSeconds(speed);
        }
    }
}
