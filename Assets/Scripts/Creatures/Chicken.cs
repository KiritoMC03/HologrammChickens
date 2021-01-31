using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chicken : Creature
{
    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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
        UpHealth(20);
    }
}
