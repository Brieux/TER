using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDoorController : MonoBehaviour {
	private float delay = 1f;
	public bool opened =false;
	private Animator anim;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance (player.transform.position, transform.position) < 1 && Input.GetKeyDown (KeyCode.S) && player.GetComponent<PlayerController> ().skills [(int)Skill.openDoor]) {
			opened = true;
		}
		if (opened) {
			if (delay > 0) {
				anim.SetBool ("Opening", true);
				anim.SetBool ("Open", false);
				//Set Opening true;
				delay -= Time.deltaTime;
			} else {
				anim.SetBool ("Opening", false);
				anim.SetBool ("Open", true);
				GetComponent<BoxCollider2D> ().isTrigger = true;
				//set Open true;
				opened = false;
			}
		}

	}
}
