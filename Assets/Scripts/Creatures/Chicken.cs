using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Creature
{
    
    void Start()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        DistanceDelta = _moveSpeed * Time.deltaTime;
    }

    void Update()
    {
        DistanceDelta = _moveSpeed * Time.deltaTime;

        if (SeeFood)
        {
            _agent.enabled = false;
        }
        else
        {
            if (_agent.enabled != true)
            {
                _agent.enabled = true;
                AgentRestarted.Invoke();
            }
        }
    }

    

    

    public void AddEat()
    {
        Debug.Log("AddEat!");
    }
}
