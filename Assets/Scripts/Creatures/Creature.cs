using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Creature : MonoBehaviour, IHealth
{
    public UnityEvent AgentRestarted;

    internal NavMeshAgent _agent;
    public float Health { get; private set; }
    public bool SeeFood { get; internal set; }
    public float DistanceDelta { get; internal set; }
    internal bool CheckedFood = false;
    [SerializeField] internal float _moveSpeed = 0.5f;
    [SerializeField] internal float _runSpeed = 1;
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        private set { _moveSpeed = value; }
    }

    private void Update()
    {
        ReduceHealth(-Time.deltaTime);
    }

    virtual public void UpHealth(float value)
    {
        Health += value;
    }

    virtual public void ReduceHealth(float value)
    {

        Health -= value;
    }
}