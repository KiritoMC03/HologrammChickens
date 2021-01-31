using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    internal HashSet<GameObject> spawnedCreatures = new HashSet<GameObject>();

    [SerializeField] internal uint count = 3;
    [SerializeField] private GameObject _creature;
    [SerializeField] private float _spread = 5f;
    [Range(0.1f, 5f)]
    [SerializeField] internal float speed = 0.5f;
    
    private Transform _transform;
    private Coroutine _spawnerRoutine;

    private void Awake()
    {
        _transform = transform;

        if (_creature == null)
        {
            throw new Exception("Поле Creature не установлено!");
        }
    }

    void Start()
    {
        _spawnerRoutine = StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        if (_creature == null)
        {
            throw new Exception("Поле Creature или Area не установлено!");
        }

        for (int i = 0; i < count; i++)
        {
            Instantiate(_creature);
            yield return new WaitForSeconds(speed);
        }
    }
}
