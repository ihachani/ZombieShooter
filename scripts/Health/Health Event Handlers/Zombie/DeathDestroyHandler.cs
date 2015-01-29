using UnityEngine;
using System.Collections;

public class DeathDestroyHandler : HealthHandler {
    NavMeshAgent agent;
    NavAgent navAgentScript;
    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        navAgentScript = GetComponent<NavAgent>();
    }
     public override void attach(Health health) {
            health.OnDeath += OnDeathEventHandler;
        }
    public virtual void OnDeathEventHandler(Health health){
        navAgentScript.enabled = false;
        agent.enabled = false;
        collider.enabled = false;
    }
}
