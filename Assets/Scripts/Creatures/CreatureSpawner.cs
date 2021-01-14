using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _creature;
    [SerializeField] private Transform _area;
    [SerializeField] private float _spread = 5f;
    [SerializeField] private uint _count = 3;
    private TerrainHandler _terrain;

    void Start()
    {
        _terrain = GameObject.FindGameObjectWithTag("MainTerrain").GetComponent<TerrainHandler>();

        if (_terrain == null)
        {
            throw new Exception("Не найдено ни одного объекта с тегом \"MainTerrain\". Установите тег на целевой объект.");
        }

        if (_creature == null)
        {
            throw new Exception("Поле Creature не установлено!");
        }
        if (_area == null)
        {
            throw new Exception("Поле Area не установлено!");
        }

        for (int i = 0; i < _count; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        if (_area == null || _creature == null)
        {
            throw new Exception("Поле Creature или Area не установлено!");
        }

        var newCreature = Instantiate(_creature, _area).transform;

        var randomSpread = new Vector3(
            UnityEngine.Random.Range(-_spread, _spread) + _terrain.Width / 2, 
            0, 
            UnityEngine.Random.Range(-_spread, _spread) + _terrain.Length / 2);

        newCreature.Translate(randomSpread);
    }
}
