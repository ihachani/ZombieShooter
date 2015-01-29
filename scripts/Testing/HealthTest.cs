using UnityEngine;
using System.Collections;

public class HealthTest : MonoBehaviour {
    Health health;
	// Use this for initialization
	void Awake () {
        health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!health.isDead())
            health.decrease(1);
	}
}
