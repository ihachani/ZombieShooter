using UnityEngine;
using System.Collections;

public class RadarHealthHandler : HealthHandler
{

    public override void attach(Health health)
    {
        health.OnDeath += OnDeathEventHandler;
        health.OnHealthUp += OnHealthUpEventHandler;
        health.OnHealthDown += OnHealthDownEventHandler;
        
    }

    public override void OnDeathEventHandler(Health health)
    {
        GameObject radarAgent = (GameObject)(GetComponent<RadarRegistery>().getNavAgents())[health.gameObject.GetComponent<NavAgent>()];
        if (radarAgent != null)
        {
            (GetComponent<RadarRegistery>().getNavAgents()).Remove(health.gameObject.GetComponent<NavAgent>());
            Destroy(radarAgent);                      
        }
    }

    public override void OnHealthUpEventHandler(Health health)
    {

    }

    public override void OnHealthDownEventHandler(Health health)
    {

    }
}
