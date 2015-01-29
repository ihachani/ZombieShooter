using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine.UI;

public class RadarAgentHandler : NavAgentHandler
{
    public GameObject referenceObject;
    public GameObject radarPrefab;
    public float mapScale = 1f;

    void Awake()
    {
    }

    public override void attach(NavAgent navAgent)
    {
        navAgent.OnNavAgentSpawn += OnNavAgentSpawnEventHandler;
        navAgent.OnNavAgentArrive += OnNavAgentArriveEventHandler;
        navAgent.OnNavAgentMove += OnNavAgentMoveEventHandler;
        navAgent.OnNavAgentDestUpdate += OnNavAgentDestUpdateEventHandler;
    }

    public void attach(FixedAgent fixedAgent)
    {
        fixedAgent.OnNavAgentSpawn += OnFixedAgentSpawnEventHandler;
        fixedAgent.OnNavAgentMove += OnFixedAgentMoveEventHandler;
    }

    public override void OnNavAgentSpawnEventHandler(NavAgent navAgent)
    {
        GameObject radarAgent = Instantiate(radarPrefab) as GameObject;
        radarAgent.transform.SetParent(GetComponent<Transform>(), false);
        radarAgent.name = navAgent.name+"__radarFollower";
        if (navAgent.mapColor != null)
        {
            Image agentBackground = radarAgent.GetComponent<Image>();
            agentBackground.color = new Color(navAgent.mapColor.r, navAgent.mapColor.g, navAgent.mapColor.b);
        }
        GetComponent<RadarRegistery>().addNavAgent(navAgent, radarAgent);
        //Debug.Log("radarAgentsContainer " + navAgent.name + "return");
    }

    public void OnFixedAgentSpawnEventHandler(FixedAgent fixedAgent)
    {
        GameObject radarAgent = Instantiate(radarPrefab) as GameObject;
        radarAgent.transform.SetParent(GetComponent<Transform>(), false);
        radarAgent.name = fixedAgent.name + "__radarFollower";
        if (fixedAgent.mapColor != null)
        {
            Image agentBackground = radarAgent.GetComponent<Image>();
            agentBackground.color = new Color(fixedAgent.mapColor.r, fixedAgent.mapColor.g, fixedAgent.mapColor.b);
        }
        GetComponent<RadarRegistery>().addFixedAgent(fixedAgent, radarAgent);
        //Debug.Log("radarAgentsContainer " + navAgent.name + "return");
    }

    public override void OnNavAgentMoveEventHandler(NavAgent navAgent, float offset)
    {
        GameObject radarAgent = (GameObject)(GetComponent<RadarRegistery>().getNavAgents())[navAgent];
        if (radarAgent != null)
        {
            Vector3 agentPosition = navAgent.gameObject.transform.position;
            Vector3 followerPosition = calculatePosition(agentPosition);
            radarAgent.GetComponent<RectTransform>().position = followerPosition;
        }
        //Debug.Log("Entering zone" + navAgent.name + " | offset" + (offset));
    }

    public void OnFixedAgentMoveEventHandler(FixedAgent fixedAgent)
    {
        GameObject radarAgent = (GameObject)(GetComponent<RadarRegistery>().getNavAgents())[fixedAgent];
        if (radarAgent != null)
        {
            Vector3 agentPosition = fixedAgent.gameObject.transform.position;
            Vector3 followerPosition = calculatePosition(agentPosition);
            radarAgent.GetComponent<RectTransform>().position = followerPosition;
        }
        //Debug.Log("Entering zone" + navAgent.name + " | offset" + (offset));
    }

    Vector3 calculatePosition(Vector3 realPosition)
    {
        float dx = realPosition.x - referenceObject.gameObject.transform.position.x;
        float dz = realPosition.z - referenceObject.gameObject.transform.position.z;
        Vector3 position = new Vector3();
        position.x = dx * mapScale + GetComponent<Transform>().position.x;
        position.y = dz * mapScale + GetComponent<Transform>().position.y;
        return position;
    }


    public override void OnNavAgentArriveEventHandler(NavAgent navAgent, float offset)
    {
        //Debug.Log("" + navAgent.name + "Arrived");
    }

    public override void OnNavAgentDestUpdateEventHandler(NavAgent navAgent, Transform target)
    {
        //Debug.Log("Updating destination" + navAgent.name + " | target" + (target.position));
    }

}
