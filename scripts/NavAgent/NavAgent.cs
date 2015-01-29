using UnityEngine;
using System.Collections;

public class NavAgent : MonoBehaviour {
	
	public Transform target;
    public NavAgentHandler[] navAgentHandler;
    public Color mapColor;
	
	// Movement Event Handler
    public delegate void OnNavAgentMoveEvent(NavAgent navAgent, float offset);
	public event OnNavAgentMoveEvent OnNavAgentMove;

    // Arrive Event Handler
    public delegate void OnNavAgentArriveEvent(NavAgent navAgent, float offset);
    public event OnNavAgentArriveEvent OnNavAgentArrive;

    // Spawn Mesh Agent Event Handler
    public delegate void OnNavAgentSpawnEvent(NavAgent navAgent);
    public event OnNavAgentSpawnEvent OnNavAgentSpawn;

    // Destination update Event Handler
    public delegate void OnNavAgentDestUpdateEvent(NavAgent navAgent, Transform target);
    public event OnNavAgentDestUpdateEvent OnNavAgentDestUpdate;

	NavMeshAgent navagentSkel;

	void Awake () {
		navagentSkel = GetComponent <NavMeshAgent> ();		
        setTarget(target);
        foreach (NavAgentHandler navAgentin in navAgentHandler) {
            navAgentin.attach(this);
        }
        OnNavAgentSpawn(this);
	}

    void setTarget(Transform target)
    {
        this.target = target;
        navagentSkel.SetDestination(target.position);
    }

    public void UpdateTarget(Transform target)
    {
        setTarget(target);
        OnNavAgentDestUpdate(this, target);
	}

	void FixedUpdate()
	{
		if (!navagentSkel.pathPending)
		{
			if (navagentSkel.remainingDistance <= navagentSkel.stoppingDistance)
			{
                if (!navagentSkel.hasPath || navagentSkel.velocity.sqrMagnitude == 0f)
                {
                    OnNavAgentArrive(this, navagentSkel.remainingDistance);
                }
			}
            OnNavAgentMove(this, navagentSkel.remainingDistance);
		}
	}
}