using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Creature))]
public class WanderMode : MonoBehaviour
{
	private TerrainHandler _terrain;
	private Transform _transform;
	private Vector3 _nextPosition = new Vector3();
	private StateController _stateController;
	[SerializeField] private Creature _creature;

	void Start()
	{
		_creature = GetComponent<Creature>();
		_transform = GetComponent<Transform>();
		_stateController = GetComponent<StateController>();
		_terrain = GameObject.FindGameObjectWithTag("MainTerrain").GetComponent<TerrainHandler>();

		if (_terrain == null)
		{
			throw new Exception("Не найдено ни одного объекта с тегом \"MainTerrain\". Установите тег на целевой объект.");
		}

		_nextPosition = _transform.position;
	}

	private void Update()
	{
		if (Mathf.Round(_transform.localPosition.x) == Mathf.Round(_nextPosition.x) ||
		Mathf.Round(_transform.localPosition.z) == Mathf.Round(_nextPosition.z))
		{
			UpdateMoveAgent();
		}
	}

	public void UpdateMoveAgent()
	{
		_nextPosition = FindNextPosition();

		if (!_creature.SeeFood)
		{
			MoveNext(_nextPosition);
		}
	}

	private void MoveNext(Vector3 nextPosition)
	{
		_creature._agent.SetDestination(nextPosition);
		_stateController.Set(StateController.States.Run);
	}

	private Vector3 FindNextPosition()
	{
		if (_terrain == null)
		{
			throw new Exception("Не найдено ни одного объекта с тегом \"MainTerrain\". Установите тег на целевой объект.");
		}

		var randomX = UnityEngine.Random.Range(_terrain.WidthOffset, _terrain.Width - _terrain.WidthOffset);
		var randomZ = UnityEngine.Random.Range(_terrain.LengthOffset, _terrain.Length - _terrain.LengthOffset);

		return new Vector3(randomX, 0, randomZ);
	}
}
