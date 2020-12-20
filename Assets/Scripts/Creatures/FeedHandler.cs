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
        if(_creature.Health < 20f)
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
        _creature.CheckedFood = true;
        var tempFood = new List<GameObject>();
        foreach (var item in _food)
        {
            if(item != null)
            {
                tempFood.Add(item);
            }
        }
        _food = tempFood;

        if (_food.Count == 0)
        {
            _creature.SeeFood = false;
        }
        else
        {
            _creature.SeeFood = true;
        }

        _creature.CheckedFood = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Food>() != null)
        {
            Debug.Log("Enter");
            if (_creature != null)
            {
                Debug.Log("Creature != null");
                if (!_creature.CheckedFood)
                {
                    Debug.Log("Add!");
                    _food.Add(other.gameObject);
                }
            }
        }
    }
}
