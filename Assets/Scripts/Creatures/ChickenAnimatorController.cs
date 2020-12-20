using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenAnimatorController : AnimatorController
{
    public void Change()
    {
        Debug.Log("Change Enter");
        if (_stateController == null)
        {
            throw new System.Exception("Поле StateController не установленно.");
        }

        Debug.Log("Change Enter");

        _animator.SetBool("Walk", false);
        _animator.SetBool("Run", false);
        _animator.SetBool("Eat", false);

        Debug.Log("Change S");
        switch (_stateController.State)
        {
            case StateController.States.Walk:
                _animator.SetBool("Walk", true);
                Debug.Log("Change A");
                break;
            case StateController.States.Run:
                _animator.SetBool("Run", true);
                Debug.Log("Change B");
                break;
            case StateController.States.Eat:
                _animator.SetBool("Eat", true);
                Debug.Log("Change C");
                break;
        }
    }
}
