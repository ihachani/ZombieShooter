using UnityEngine;
using System;

public class WeaponRotation : MonoBehaviour {


	int floorMask;
	// Use this for initialization
	void Start () {
		floorMask = LayerMask.GetMask ("Quader");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Turn(Touch touch) {
		Vector3 touchPos;
		touchPos.x = touch.position.x;
		touchPos.y = touch.position.y;
		touchPos.z = GameObject.Find ("Floor").transform.position.z;
		Ray touchRay = Camera.main.ScreenPointToRay (touchPos);
		Debug.Log (touch.position + "  touch pos  ");
		RaycastHit touchHit;
		if ( Physics.Raycast (touchRay, out touchHit, float.MaxValue, floorMask) ) {
			double adj = Math.Abs (transform.position.z - GameObject.Find ("Floor").transform.position.z);
			double angle = Math.Atan ((-transform.position.x + touchHit.point.x) / adj);
			Quaternion target = Quaternion.Euler (transform.eulerAngles.x,(float)( angle * 180 / System.Math.PI), transform.eulerAngles.z);
			transform.localRotation = target;
			Debug.Log ("opposee " + (touchHit.point.x - transform.position.x) + "   adj: " + adj + "  angle  " + target.eulerAngles.y);
		}
	}
}
