using UnityEngine;
using System.Collections;

public class MvntBtn : MonoBehaviour {

	bool pressed = false;
	private GameObject player;
	private PlayerMovement playerMovement;
	public float mvntVariation = 0.09f;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerMovement = player.GetComponent<PlayerMovement> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (pressed) {
			Debug.Log ("clicked");
			if(player != null && playerMovement != null) {
				playerMovement.Move(mvntVariation);
			}
		}
	}

	public void setPressed(bool pressed) {
		this.pressed = pressed;
	}
}
