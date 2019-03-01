using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour {
	public float posX, posY;
	public Transform Joueur;
	
	// Use this for initialization
	void Start () {
		posX = Joueur.localPosition.x;
		posY = Joueur.localPosition.y;

	}

	// Update is called once per frame
	void Update () {
		Vector3 cameraPlace;
		cameraPlace.x = Joueur.localPosition.x;
		cameraPlace.y = Joueur.localPosition.y;
		cameraPlace.z = -30;
		transform.localPosition = cameraPlace;
	}
}
