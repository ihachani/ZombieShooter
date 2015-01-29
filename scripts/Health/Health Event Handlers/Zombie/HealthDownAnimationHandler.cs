using UnityEngine;
using System.Collections;

public class HealthDownAnimationHandler : HealthHandler {
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public override void attach(Health health) {
        health.OnHealthDown += OnHealthDownEventHandler;
    }
    public virtual void OnHealthDownEventHandler(Health health)
    {
        animator.SetTrigger("Hit");
    }
}
