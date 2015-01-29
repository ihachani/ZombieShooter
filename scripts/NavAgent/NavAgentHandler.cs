using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NavAgentHandler : MonoBehaviour
{
    public float attachedZone;

    public virtual void attach(NavAgent navAgent)
    {
        navAgent.OnNavAgentSpawn += OnNavAgentSpawnEventHandler;
        navAgent.OnNavAgentArrive += OnNavAgentArriveEventHandler;
        navAgent.OnNavAgentMove += OnNavAgentMoveEventHandler;
        navAgent.OnNavAgentDestUpdate += OnNavAgentDestUpdateEventHandler;
    }

    public virtual void OnNavAgentSpawnEventHandler(NavAgent navAgent)
    {
        Debug.Log("Enemy " + navAgent.name + "created");
    }

    public virtual void OnNavAgentMoveEventHandler(NavAgent navAgent, float offset)
    {
        Debug.Log("Entering zone" + navAgent.name + " | offset" + (offset));
    }

    public virtual void OnNavAgentArriveEventHandler(NavAgent navAgent, float offset)
    {
        Debug.Log("" + navAgent.name + "Arrived");
    }

    public virtual void OnNavAgentDestUpdateEventHandler(NavAgent navAgent, Transform target)
    {
        Debug.Log("Updating destination" + navAgent.name + " | target" + (target.position));
    }
}
