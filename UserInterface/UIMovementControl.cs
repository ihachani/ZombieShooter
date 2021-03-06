﻿using UnityEngine;
using System.Collections;

public class UIMovementControl : MonoBehaviour
{

    public GameObject controlGameObject;

	void Start () {
        createControlUI();
	}

    protected void createControlUI()
    {
        GameObject currentWeaponControl = Instantiate(controlGameObject) as GameObject;
        currentWeaponControl.transform.SetParent(transform);
        Vector2 offsetMax = new Vector2(0f, 0f);
        Vector2 offsetMin = new Vector2(0, 10f);
        Vector2 anchorMax = new Vector2(1f, 1f);
        Vector2 anchorMin = new Vector2(0f, 0f);
        currentWeaponControl.GetComponent<RectTransform>().offsetMax = offsetMax;
        currentWeaponControl.GetComponent<RectTransform>().offsetMin = offsetMin;
        currentWeaponControl.GetComponent<RectTransform>().anchorMax = anchorMax;
        currentWeaponControl.GetComponent<RectTransform>().anchorMin = anchorMin;
    }
}
