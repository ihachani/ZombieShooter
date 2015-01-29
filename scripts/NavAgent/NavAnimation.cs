using UnityEngine;
using System.Collections;

public class NavAnimation : MonoBehaviour {
    NavMeshAgent agent;
    // public Transform target; Testing only
    float speed;
    Animator animatorController;
	// Use this for initialization
	void Awake () {
        agent = GetComponent<NavMeshAgent>();
        animatorController = GetComponent<Animator>();
        //agent.SetDestination(target.position); Testing only
	}
	
	// Update is called once per frame
    void OnAnimatorMove () {
	    speed = agent.velocity.magnitude;
        animatorController.SetFloat("Speed", speed);
        
        Vector3 velocity = Quaternion.Inverse(transform.rotation) * agent.desiredVelocity;
        float angle = Mathf.Atan2(velocity.x, velocity.y) * 180 / 3.14159f;
        animatorController.SetFloat("AV", Mathf.Abs(angle));
    }
}
