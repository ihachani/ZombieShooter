using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIWeaponsManager : MonoBehaviour
{
    public GameObject weaponControl;
    public GameObject menuControlUI;
    public Weapon[] weapons;

    void Awake()
    {
        GameObject menuUI = CreateControlCanvasAt(0);
        AddMenuControl(menuControlUI, menuUI);

        int id = 1;
        foreach (Weapon weapon in weapons)
        {
            GameObject controlUI = CreateControlCanvasAt(id);
            AddWeaponControl(weapon, controlUI);
            id++;
        }
    }

    protected void AddWeaponControl(Weapon weapon, GameObject container)
    {
        container.name = "weaponControl_" + weapon.name;
        (container.GetComponent<Image>()).sprite = (weapon.GetComponent<Image>()).sprite;
    }

    protected void AddMenuControl(GameObject menuUI, GameObject container)
    {
        container.name = "menuControl_" + menuUI.name;
        (container.GetComponent<Image>()).sprite = (menuUI.GetComponent<Image>()).sprite;
    }

    protected GameObject CreateControlCanvasAt(int id)
    {
        GameObject currentWeaponControl = Instantiate(weaponControl) as GameObject;
        currentWeaponControl.transform.SetParent(transform);
        Vector2 offsetMax = new Vector2(-5f, -10f);
        Vector2 offsetMin = new Vector2(5f, 0);
        Vector2 anchorMax = new Vector2(1 - 0.15f * id, 1f);
        Vector2 anchorMin = new Vector2(0.85f - 0.15f * id, 0f);
        currentWeaponControl.GetComponent<RectTransform>().offsetMax = offsetMax;
        currentWeaponControl.GetComponent<RectTransform>().offsetMin = offsetMin;
        currentWeaponControl.GetComponent<RectTransform>().anchorMax = anchorMax;
        currentWeaponControl.GetComponent<RectTransform>().anchorMin = anchorMin;
        return currentWeaponControl;
    }

}
