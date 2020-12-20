using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(StateController))]
public class AnimatorController : MonoBehaviour
{
    protected Animator _animator;
    protected StateController _stateController;

    protected void Start()
    {
        _animator = GetComponent<Animator>();
        _stateController = GetComponent<StateController>();
    }

    /*protected void Change()
    {
        if(_stateController == null)
        {
            throw new System.Exception("Поле StateController не установленно.");
        }

        _animator.SetBool("Walk", false);
        _animator.SetBool("Run", false);
        _animator.SetBool("Eat", false);

        switch (_stateController.State)
        {
            case StateController.States.Walk:
                _animator.SetBool("Walk", true);
                break;
            case StateController.States.Run:
                _animator.SetBool("Run", true);
                break;
            case StateController.States.Eat:
                _animator.SetBool("Eat", true);
                break;
        }
    }*/
}
