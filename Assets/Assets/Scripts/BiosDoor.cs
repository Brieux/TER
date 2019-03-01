using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiosDoor : MonoBehaviour
{
	public AudioClip music;
	private AudioSource source;
    [SerializeField] Vector2 position;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
		source = player.GetComponent<AudioSource> ();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="Player")
        {
            player.GetComponent<Rigidbody2D>().position = position;
			source.Stop();
			source.PlayOneShot (music);
        }
    }
}
