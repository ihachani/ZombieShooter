using UnityEngine;
using System.Collections;

public class FixedAgent : MonoBehaviour {

    public RadarAgentHandler[] fixedAgentHandler;
    public Color mapColor;

    // Spawn Mesh Agent Event Handler
    public delegate void OnNavAgentSpawnEvent(FixedAgent navAgent);
    public event OnNavAgentSpawnEvent OnNavAgentSpawn;

    // Movement Event Handler
    public delegate void OnNavAgentMoveEvent(FixedAgent navAgent);
    public event OnNavAgentMoveEvent OnNavAgentMove;


    void Awake()
    {
        foreach (RadarAgentHandler fixedAgentin in fixedAgentHandler)
        {
            fixedAgentin.attach(this);
        }
        OnNavAgentSpawn(this);
    }

    void OnAnimatorMove()
    {
        OnNavAgentMove(this);
    }

}
