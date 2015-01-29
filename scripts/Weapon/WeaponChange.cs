using UnityEngine;
using System.Collections;

public class weaponChange : MonoBehaviour {
	WeaponShoot weaponShoot;

	// Use this for initialization
	void Awake()
	{   
		SelectWeapon(0);
		weaponShoot = GetComponent<WeaponShoot>();

	}

	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown("a"))
		{   
			SelectWeapon(0);
			weaponShoot.damagePerShot=20;
			weaponShoot.range = 100f;
			weaponShoot.timeBetweenBullets = 0.15f;

		}
		else if(Input.GetKeyDown("z"))
		{
			SelectWeapon(1);
			weaponShoot.damagePerShot=50;
			weaponShoot.range = 150f;
			weaponShoot.timeBetweenBullets = 0.2f;

		
		}
	}
	void SelectWeapon( int index)
	{
		for (int i=0;i<transform.childCount;i++)
		{
			// Activate the selected weapon
			if (i == index)
			{   
				transform.GetChild(i).gameObject.SetActive(true);
			}
			// Deactivate all other weapons
			else
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}
