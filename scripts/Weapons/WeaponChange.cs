using UnityEngine;
using System.Collections;

//public class WeaponChange : MonoBehaviour
//{
//    WeaponShoot weaponShoot;
//    void Awake()
//    {

//        // Select the first weapon
//        weaponShoot = GetComponent<WeaponShoot>();
//        SelectWeapon(0);

//    }
//    void Update()
//    {

//        //Check if the fire button was pressed




//        if (Input.GetKeyDown("1"))
//        {

//            SelectWeapon(0);
//            weaponShoot.damagePerShot = 20;
//            weaponShoot.timeBetweenBullets = 0.15f;
//            weaponShoot.range = 10f;
//        }

//        else if (Input.GetKeyDown("2"))
//        {

//            SelectWeapon(1);
//            weaponShoot.damagePerShot = 100;
//            weaponShoot.timeBetweenBullets = 0.1f;
//            weaponShoot.range = 15f;
//        }

//    }



//    void SelectWeapon(int index)
//    {

//        for (var i = 0; i < transform.childCount; i++)
//        {

//            // Activate the selected weapon

//            if (i == index)
//            {

//                transform.GetChild(i).gameObject.SetActive(true);

//            }

//            // Deactivate all other weapons

//            else
//            {

//                transform.GetChild(i).gameObject.SetActive(false);

//            }

//        }
//    }
//}
