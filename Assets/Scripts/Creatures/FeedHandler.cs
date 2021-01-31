using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Creature))]
[RequireComponent(typeof(StateController))]
public class FeedHandler : MonoBehaviour
{
    private Transform _transform;
    private Creature _creature;
    private StateController _stateController;
    private List<GameObject> _food = new List<GameObject>();
    private List<GameObject> _tempFood = new List<GameObject>();

    void Start()
    {
        _transform = transform;
        _creature = GetComponent<Chicken>();
        _stateController = GetComponent<StateController>();
    }

    void Update()
    {
        GoToFood();
    }

    private void GoToFood()
    {
        if (_creature == null)
        {
            throw new System.Exception("Поле Creature не установлено!");
        }

        CheckFoodList();

        if (_food.Count == 0)
        {
            return;
        }

        _transform.position = Vector3.MoveTowards(_transform.position, _food[0].transform.position, _creature.DistanceDelta);
        if(_creature.health < 20f)
        {
            _stateController.Set(StateController.States.Run);
        }
        else
        {
            _stateController.Set(StateController.States.Walk);
        }

    }

    private void CheckFoodList()
    {
        _creature.checkedFood = true;

        for (int i = 0; i < _food.Count; i++)
        {
            /*
            if(_food[i] != null)
            {
                _food.Remove(_food[i]);
            }
            */

            if (_food[i] != null)
            {
                _tempFood.Add(_food[i]);
            }
        }
        _food = _tempFood;

        if (_food.Count == 0)
        {
            _creature.SeeFood = false;
        }
        else
        {
            _creature.SeeFood = true;
        }

        _creature.checkedFood = false;
        _tempFood.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Food>() != null)
        {
            if (_creature != null)
            {
                if (!_creature.checkedFood)
                {
                    _food.Add(other.gameObject);
                }
            }
        }
    }
}
