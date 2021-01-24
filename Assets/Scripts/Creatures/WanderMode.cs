using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Creature))]
public class WanderMode : MonoBehaviour
{
	[SerializeField] private Creature _creature;

	private TerrainSizes _terrain;
	private Transform _transform;
	private Vector3 _nextPosition = new Vector3();
	private StateController _stateController;


	void Start()
	{
		_creature = GetComponent<Creature>();
		_transform = GetComponent<Transform>();
		_stateController = GetComponent<StateController>();
		_terrain = GameObject.FindGameObjectWithTag("MainTerrain").GetComponent<TerrainSizes>();

		if (_terrain == null)
		{
			throw new Exception("Не найдено ни одного объекта с тегом \"MainTerrain\". Установите тег на целевой объект.");
		}
		_nextPosition = _transform.localPosition;
	}

	private void Update()
	{
		if (Mathf.Round(_transform.localPosition.x) == Mathf.Round(_nextPosition.x) ||
		Mathf.Round(_transform.localPosition.z) == Mathf.Round(_nextPosition.z))
		{
			Debug.Log("UpdateMoveAgent();");
			UpdateMoveAgent();
		}
	}

	public void UpdateMoveAgent()
	{
		_nextPosition = FindNextPosition() + _terrain.worldOffset;
		Debug.Log("_nextPosition: " + _nextPosition);

		if (!_creature.SeeFood && _creature.health > 20)
		{
			MoveNext(_nextPosition, StateController.States.Walk);
		}

		if (!_creature.SeeFood && _creature.health < 20)
		{
			MoveNext(_nextPosition, StateController.States.Run);
		}
	}

	private void MoveNext(Vector3 nextPosition, StateController.States movementMode)
	{
        _creature.agent.SetDestination(nextPosition);
		
		if(movementMode == StateController.States.Walk)
        {
			_creature.agent.speed = _creature.moveSpeed;
		}
		else
		{
			_creature.agent.speed = _creature.runSpeed;
		}

		_stateController.Set(movementMode);
	}

	private Vector3 FindNextPosition()
	{
		if (_terrain == null)
		{
			throw new Exception("Не найдено ни одного объекта с тегом \"MainTerrain\". Установите тег на целевой объект.");
		}

		var randomX = UnityEngine.Random.Range(_terrain.widthOffset, _terrain.width - _terrain.widthOffset);
		var randomZ = UnityEngine.Random.Range(_terrain.lengthOffset, _terrain.length - _terrain.lengthOffset);

		return new Vector3(randomX, 0, randomZ);
	}
}