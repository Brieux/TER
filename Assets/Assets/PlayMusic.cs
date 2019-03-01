using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {

	public AudioClip music;
	private GameObject player;
	private AudioSource source;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		source = player.GetComponent<AudioSource> ();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			source.Stop();
			source.PlayOneShot (music);
		}
	}
		

	// Update is called once per frame
	void Update () {
		
	}
}
