using UnityEngine;
using System.Collections;

public class HealthDeadAnimationHandler : HealthHandler {
    Animator animator;
    bool dead = false;
    void Awake(){
        animator = GetComponent<Animator>();
    }
    public override void attach(Health health) {
        health.OnDeath += OnDeathEventHandler;
    }
    void Update(){
        if (dead) {
            if (animator.GetCurrentAnimatorStateInfo(3).normalizedTime < 0.5f)
            {
                //waitAnimationEnd();
            }
            else
            {
                Vector3 dest = transform.position + new Vector3(0f, -0.8f, 0f);
                transform.position = Vector3.Lerp(transform.position, dest, 1f * Time.deltaTime);
                if(transform.position.y < -0.8f)
                    Destroy(gameObject);
            }

        }
    }

    public virtual void OnDeathEventHandler(Health health) {
        animator.SetTrigger("FallBack");
        dead = true;

    }
}
