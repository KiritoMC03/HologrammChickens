using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(Creature))]
public class StateController : MonoBehaviour
{
    public UnityEvent StateChange;

    [SerializeField] internal AnimatorController _animatorController;
    internal States State { get; set; } = States.Walk;

    void Start()
    {
        if(_animatorController == null)
        {
            _animatorController = GetComponent<AnimatorController>();
            if(_animatorController == null)
            {
                throw new Exception("Не установлено поле AnimatorController!");
            }
        }
    }

    internal void Set(States state)
    {
        State = state;
        StateChange?.Invoke();
    }

    internal enum States
    {
        Walk,
        Run,
        Eat
    }
}
