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

    public static float SCALE = 160f;

    void Awake () {
        for (float z = startRay; z <= endRay; z += rayOffset)
        {
            float e = (z / (endRay - startRay));
            float pos = obstaclesDistribution.Evaluate(e);
            float obstacles = Mathf.Round(maxObstacles * pos);
            float left = -marginOffset, right = 0;
            for (float j = 1f; j <= obstacles; j += 1)
            {
                Vector3 positionVector = new Vector3(0, 0, z); ;
                if (j % 2 == 0)
                {
                    positionVector.x = left;
                    left -= marginOffset;
                }
                else
                {
                    positionVector.x = right;
                    right += marginOffset;
                }
                createObstacle(positionVector);
                //Debug.Log("instanciate obstacle at" + positionVector.x + "||" + positionVector.z);
            }
        }
        Debug.Log("end");
	}

    GameObject createObstacle(Vector3 position)
    {
        int selection = (new System.Random()).Next(1, obstaclePrefab.Length) - 1;
        GameObject obstacle = Instantiate(obstaclePrefab[selection]) as GameObject;
        obstacle.transform.position = position;
        obstacle.transform.parent = transform;
        obstacle.layer = gameObject.layer;
        return obstacle;
    }

}
