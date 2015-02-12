using UnityEngine;
using System.Collections;

public class BonusManager : MonoBehaviour {

	public virtual void spawnBonusAs(Bonus bonusprefab, DroppableProvider provider, int bonusValue)
    {
        Bonus bonusObject = Instantiate(bonusprefab) as Bonus;
        bonusObject.transform.SetParent(GetComponent<Transform>(), false);
        bonusObject.set(bonusValue);
        bonusObject.transform.position = provider.transform.position;
        bonusObject.show();
    }
}
