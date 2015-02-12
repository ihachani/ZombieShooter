using UnityEngine;
using System.Collections;

public class DroppableProvider : HealthHandler
{

    public int bonus;
    public Bonus bonusprefab;
    public BonusManager bonusManager;
    
    public override void attach(Health health)
    {
        health.OnDeath += OnDeathEventHandler;
    }

    public override void OnDeathEventHandler(Health health)
    {
        bonusManager.spawnBonusAs(bonusprefab, this, bonus);
    }

}
