using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HealthHandler : MonoBehaviour
{

    public virtual void attach(Health health)
    {
        health.OnDeath += OnDeathEventHandler;
        health.OnHealthUp += OnHealthUpEventHandler;
        health.OnHealthDown += OnHealthDownEventHandler;
    }

    public virtual void OnDeathEventHandler(Health health)
    {

    }

    public virtual void OnHealthUpEventHandler(Health health)
    {

    }

    public virtual void OnHealthDownEventHandler(Health health)
    {

    }
}
