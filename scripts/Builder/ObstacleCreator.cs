using UnityEngine;
using System.Collections;
using System;

public class ObstacleCreator : MonoBehaviour {

    public GameObject[] obstaclePrefab;
    public AnimationCurve obstaclesDistribution;
    public float rayOffset = 3f;
    public int maxObstacles = 5;
    public float startRay = 6.1f;
    public float endRay = 13.5f;
    public float marginOffset = 12f;

    void Awake () {
        for (float z = startRay; z <= endRay; z += rayOffset)
        {
            float e = (z / (endRay - startRay));
            float pos = obstaclesDistribution.Evaluate(e);
            float obstacles = Mathf.Round(maxObstacles * pos);
            float x = 0;
            for (float j = 1f; j <= obstacles; j += 2)
            {
                createObstacle(new Vector3(x, 0, z));
                if (x!=0)  createObstacle(new Vector3(-x, 0, z));
                x += marginOffset;
            }
        }        
	}

    GameObject createObstacle(Vector3 position)
    {
        int selection = (new System.Random()).Next(0, obstaclePrefab.Length);
        GameObject obstacle = Instantiate(obstaclePrefab[selection]) as GameObject;
        obstacle.transform.position = position;
        obstacle.transform.SetParent(transform, false);
        obstacle.layer = gameObject.layer;
        return obstacle;
    }

}
