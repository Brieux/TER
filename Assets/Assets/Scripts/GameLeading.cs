using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLeading : MonoBehaviour
{
	public Text TimerHud;
    public float chronoStatic = 30f;
    public bool timeFreezing = true;
    public List<GameObject> ObjetTemporaire;
    public float chrono= 30f;
    public int knowledge = 0;
    public Vector2 destination;
	public AudioClip music;
	private AudioSource source;

    private GameObject player;

    private void Start()
    {
        ObjetTemporaire = new List<GameObject>();

        player = GameObject.Find("Player");
        chrono = chronoStatic;
		source = player.GetComponent<AudioSource> ();
    }

    private void FixedUpdate()
    {
		TimerHud.text = ((int)chrono).ToString ();
        if (timeFreezing == false)
        {
            if (chrono <= 0)
            {
                chrono = chronoStatic;
                player.GetComponent<PlayerController>().knowledge = 0;
                foreach (GameObject neurone in ObjetTemporaire)
                {
                    neurone.SetActive(true);
                }
                ObjetTemporaire = new List<GameObject>();
                player.GetComponent<Rigidbody2D>().position = destination;
				GameObject.Find ("Main Camera").transform.position = new Vector3 (destination.x, destination.y, -2f);
				source.Stop();
				source.PlayOneShot (music);
            }
            else
            {
                chrono -= Time.deltaTime;
            }
        }
    }
}
