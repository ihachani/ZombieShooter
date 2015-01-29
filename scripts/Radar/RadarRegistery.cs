using UnityEngine;
using System.Collections;

public class RadarRegistery : MonoBehaviour
{

    public Hashtable navAgents = new Hashtable();

    void Awake()
    {
    }

    public Hashtable getNavAgents()
    {
        return navAgents;
    }

    public void addNavAgent(NavAgent navAgent, GameObject radarAgent)
    {
        navAgents.Add(navAgent, radarAgent);
    }

    public void addFixedAgent(FixedAgent fixedAgent, GameObject radarAgent)
    {
        navAgents.Add(fixedAgent, radarAgent);
    }
    
}
