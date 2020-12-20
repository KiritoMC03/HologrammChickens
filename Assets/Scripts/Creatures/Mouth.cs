using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Mouth : MonoBehaviour, IEat
{
    [SerializeField] private Creature _creature;

    void Start()
    {
        _creature = _creature.GetComponent<Creature>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var foodComponent = other.GetComponent<Food>();
        if (foodComponent != null)
        {
            Debug.Log("Food Get");
            Eat(foodComponent.cost);
            Destroy(other.gameObject);
        }
    }

    public void Eat(float value)
    {
        _creature.UpHealth(value);
    }
}