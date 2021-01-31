using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Creature : MonoBehaviour, IHealth
{
    public UnityEvent AgentRestarted;
    public UnityEvent ReachedCriticalHealth;

    internal NavMeshAgent agent;
    [SerializeField] internal float health = 100;
    [SerializeField] internal float criticalHealth = 20;
    public bool SeeFood { get; internal set; }
    public float DistanceDelta { get; internal set; }
    internal bool checkedFood = false;
    [SerializeField] internal float moveSpeed = 0.5f;
    [SerializeField] internal float runSpeed = 1;

    private void Awake()
    {
        if (criticalHealth >= health)
        {
            throw new Exception("CriticalHealth должен быть меньше Health.");
        }
    }

    private void Update()
    {
        ReduceHealth(-Time.deltaTime);
    }

    virtual public void UpHealth(float value)
    {
        health += value;
    }

    virtual public void ReduceHealth(float value)
    {
        health -= value;
        if(health <= criticalHealth)
        {
            ReachedCriticalHealth?.Invoke();
        }
        else if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}