using UnityEngine;
using System.Collections;

public class UiResAdapt : MonoBehaviour {

	const int defaultHeight = 1080;

	float ratio = Screen.height / defaultHeight;

	GameObject[] uis;

	void Awake () {
		uis = GameObject.FindGameObjectsWithTag ("ui");
		Scale ();
	}
	void Scale() {

		foreach(GameObject obj in uis ) {
			obj.transform.localScale += new Vector3(ratio, ratio, 0f);
		}

	}
}
