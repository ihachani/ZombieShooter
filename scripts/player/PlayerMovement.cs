using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {
	
	public float movementFactor = 0.01f;	
	public float rotationSensitivity = 1f;

	void Awake () {
		
	}
	
	void FixedUpdate () {
		// returns -1, 1 if an input axis state changed or 0 ifnot 
		float x = Input.acceleration.x;
		//Move (x);
		Turning ();
	}
	
	// responsible for player movement
	public void Move(float x) {
		transform.Translate (movementFactor * x, 0f, 0f, Space.World);
	}

	// responsible for player turning when swipe the screen
	void Turning() {
		if (Input.touchCount == 0) 
				return;
		for (int i = 0; i < Input.touchCount; i++) { 
			if (Input.touchCount > 0 && Input.GetTouch (i).phase == TouchPhase.Moved && Input.GetTouch (i).phase != TouchPhase.Stationary) {
			float ratio = Input.GetTouch (i).deltaPosition.x / Screen.width;
				Quaternion target = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y + 60 * rotationSensitivity * ratio, transform.eulerAngles.z);
			if (Input.GetTouch (i).deltaPosition.x < 0) {
				if (target.eulerAngles.y < 320 && target.eulerAngles.y > 30)
					target.eulerAngles = new Vector3 (target.eulerAngles.x, 320, target.eulerAngles.z);
			} else {
				if (target.eulerAngles.y > 30 && target.eulerAngles.y < 180)
					target.eulerAngles = new Vector3 (target.eulerAngles.x, 30, target.eulerAngles.z);
			}
			transform.rotation = target;
			}
		}
	}
}