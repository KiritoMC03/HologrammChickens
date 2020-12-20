using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(Creature))]
public class StateController : MonoBehaviour
{
    public UnityEvent StateChange;

    [SerializeField] internal AnimatorController _animatorController;
    internal States State { get; set; }

    void Start()
    {
        if(_animatorController == null)
        {
            _animatorController = GetComponent<AnimatorController>();
            if(_animatorController == null)
            {
                throw new Exception("Не установлено поле AnimatorController или не найдено компонента AnimatorController!");
            }
        }
    }

    internal void Set(States state)
    {
        State = state;
        if(StateChange != null) // ToDo: Нужно ли?
        {
            StateChange.Invoke();
        }
    }

    internal enum States
    {
        Walk,
        Run,
        Eat
    }
}
