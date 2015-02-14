using UnityEngine;
using System.Collections;

public class ZombieCloner : Cloner {

    public int droppableChance = 5;
    public int minDamage = 10;
    public int maxDamage = 10;
    public int minHealth = 1;
    public int maxHealth = 100;
    public int minBonuse = 5;
    public int maxBonuse = 10;

    public override GameObject clone(GameObject parent)
    {
        GameObject clone = base.clone(parent);
        Health cloneHealth = clone.GetComponent<Health>();
        if (cloneHealth == null) cloneHealth = clone.AddComponent<Health>();
        cloneHealth.setMax((new System.Random()).Next(minHealth, maxHealth + 1));
        cloneHealth.set(cloneHealth.getMax());

        ZombieAttackTargetHandler cloneZombieAttackTargetHandler = clone.GetComponent<ZombieAttackTargetHandler>();
        if (cloneZombieAttackTargetHandler == null) cloneZombieAttackTargetHandler = clone.AddComponent<ZombieAttackTargetHandler>();
        cloneZombieAttackTargetHandler.damage = (new System.Random()).Next(minDamage, maxDamage + 1);

        if ((new System.Random()).Next(1, 11) <= droppableChance)
        {
            DroppableProvider droppableProvider = clone.AddComponent<DroppableProvider>();
            droppableProvider.bonus = (new System.Random()).Next(minBonuse, maxBonuse + 1);
            droppableProvider.bonusManager = BonusManager.getCurrentInstance();
            droppableProvider.bonusprefab = (Resources.Load("Droppables/Droppable_1") as GameObject).GetComponent<Bonus>();
        }

        SkinnedMeshRenderer zombieMesh =clone.GetComponentInChildren<SkinnedMeshRenderer>();
        if (zombieMesh != null)
        {
            zombieMesh.material = Instantiate(Resources.Load("Material/zombie/Zombie_1")) as Material;
        }

        return clone;
    }

}
