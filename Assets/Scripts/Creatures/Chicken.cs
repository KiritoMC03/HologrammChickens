using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Creature
{
    
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        DistanceDelta = moveSpeed * Time.deltaTime;
    }

    void Update()
    {
        DistanceDelta = moveSpeed * Time.deltaTime;

        if (SeeFood)
        {
            agent.enabled = false;
        }
        else
        {
            if (agent.enabled != true)
            {
                agent.enabled = true;
                AgentRestarted.Invoke();
            }
        }
    }

    public void AddEat()
    {
        Debug.Log("AddEat!");
    }
}
