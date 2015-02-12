using UnityEngine;
using System.Collections;

public class BonusesHealthHandler : HealthHandler {

    public Health player;

    public virtual void attach(Health health)
    {
        health.OnDeath += OnDeathEventHandler;
    }

    public virtual void OnDeathEventHandler(Health health)
    {
        Bonus bonus = health.GetComponent<Bonus>();
        player.increase(bonus.get());
        bonus.consume();
    }
}
