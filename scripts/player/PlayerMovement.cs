using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {
	
	// movement foctors
	public float movementFactor = 0.01f;	
	public float rotationSensitivity = 1f;
	public float tapRange = 0f;
	
	enum TOUCH_STATE {
		SWIPING,
		TAP,
		NONE
	}
	
	// touch states related vars
	static int maxTouch = 4;
	TOUCH_STATE[] touchStates = new TOUCH_STATE[maxTouch];
	Vector2[] lastPos = new Vector2[maxTouch];
	float[] lastTime = new float[maxTouch];
	float[] touchRange = { 33 + 220 * UiResAdapt.ratio, Screen.width - 33 - 220 * UiResAdapt.ratio, 17 + 220 * UiResAdapt.ratio };
	int floorMask;
	
	// components
	private Rigidbody playerRigidBody;
	WeaponShoot shootingSystem ;
	GameObject weaponGO;

	
	void Awake () {
		playerRigidBody = GetComponent<Rigidbody> ();
		weaponGO = GameObject.FindGameObjectWithTag ("weaponGO");
		shootingSystem = weaponGO.GetComponent<WeaponShoot> ();
		for (int t = 0; t < maxTouch; t++)
			touchStates [t] = TOUCH_STATE.NONE;
		floorMask = LayerMask.GetMask ("Quader");
	}
	
	void Update () {
		// returns -1, 1 if an input axis state changed or 0 ifnot 
		float x = Input.acceleration.x;
		//Move (x);
		touchState ();
	}
	
	// responsible for player movement
	public void Move(float x) {
		if (playerRigidBody != null) {
			Vector3 movement = new Vector3(transform.position.x + movementFactor * x, transform.position.y, transform.position.z);
			playerRigidBody.MovePosition(movement);
			//Debug.Log (transform.position.x + "  " + transform.position.y + "  " + transform.position.z);
			
		}
	}
	
	
	// touch state
	void touchState() {
		if (Input.touchCount > 0) {
			for(int i = 0 ; i < Input.touchCount ; i++ ) {
				if( Input.GetTouch(i).phase == TouchPhase.Began ) {
					lastPos[i] = Input.GetTouch(i).position;
					lastTime[i] = Time.time;
				}
				if(Input.GetTouch(i).phase == TouchPhase.Ended) {
					if(touchStates[i] == TOUCH_STATE.SWIPING) {
						touchStates[i] = TOUCH_STATE.NONE;
					} else {
						if( lastPos[i] != null ) {
							if((Math.Abs (Input.GetTouch(i).position.x - lastPos[i].x) < tapRange * UiResAdapt.ratio) && touchStates[i] == TOUCH_STATE.NONE && isTouchInRange(i)) {
								touchStates[i] = TOUCH_STATE.TAP;
								Turn (Input.GetTouch(i));
								ApplyAction(i);
								touchStates[i] = TOUCH_STATE.NONE;
							}
						}
					}
				}
				if(Input.GetTouch(i).phase == TouchPhase.Moved ) {
					if(Math.Abs (Input.GetTouch(i).position.x - lastPos[i].x) >= tapRange * UiResAdapt.ratio || Math.Abs (Input.GetTouch(i).position.y - lastPos[i].y) >= tapRange * UiResAdapt.ratio) {
						touchStates[i] = TOUCH_STATE.SWIPING;
					}
				}
				ApplyAction(i);
			}
			
		}
		
	}
	void Turn(Touch touch) {
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
			transform.rotation = target;
			Debug.Log ("opposee " + (touchHit.point.x - transform.position.x) + "   adj: " + adj + "  angle  " + target.eulerAngles.y);
		}
	}

	void Turn(int i) {
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
	
	void ApplyAction(int i) {
		if (touchStates [i] == TOUCH_STATE.SWIPING) {
			Turn (i);
		} else if(touchStates [i] == TOUCH_STATE.TAP) {
			shootingSystem.Shoot();
		}
	}
	
	bool isTouchInRange(int i) {
		return (Input.GetTouch(i).position.y < touchRange[2] ? (Input.GetTouch(i).position.x > touchRange[0] &&  Input.GetTouch(i).position.x < touchRange[1]) : true);
	}
	
}