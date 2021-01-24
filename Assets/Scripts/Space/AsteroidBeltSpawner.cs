using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBeltSpawner : MonoBehaviour
{
    [SerializeField] private int _count = 100;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _sun;
    [SerializeField] private float _distanceToSun = 35f;
    [SerializeField] private float _spread = 3.5f;
    [SerializeField] private float _speedSpread = 100f;

    private Transform _transform;
    

    void Start()
    {
        _transform = transform;

        if (_prefab == null)
        {
            throw new NullReferenceException("Prefab");
        }
        if (_sun == null)
        {
            throw new NullReferenceException("Sun");
        }
        else
        {
            transform.position = _sun.transform.position;
        }


        Generate();
    }

    private void Generate()
    {
        if (_prefab == null || _sun == null) return;

        var offset = _sun.transform.position;

        for (int i = 0; i < _count; i++)
        {
            var newAsteroid = Instantiate(_prefab, offset, Quaternion.identity, _transform).GetComponent<OrbitMovement>();

            if(newAsteroid != null)
            {
                var asteroidPositionX = _distanceToSun + UnityEngine.Random.Range(-_spread, _spread);
                var asteroidPositionY = _distanceToSun + UnityEngine.Random.Range(-_spread, _spread);
                var asteroidPositionZ = UnityEngine.Random.Range(-_spread, _spread);

                newAsteroid.orbitPath = new Orbit(asteroidPositionX, asteroidPositionY);
                newAsteroid.orbitProgress = UnityEngine.Random.Range(0f, 1f);
                newAsteroid.orbitPeriod += UnityEngine.Random.Range(-_speedSpread, _speedSpread);
            }
        }
    }
}
