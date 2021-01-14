using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenAnimatorController : AnimatorController
{
    override public void Change()
    {
        if (_stateController == null)
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
    }
}
