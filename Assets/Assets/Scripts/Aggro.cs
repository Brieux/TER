using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggro : MonoBehaviour
{
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float attackCooldownStatic = 2f;

	public AudioClip music;
	private GameObject player;
	private AudioSource source;
    private bool directionDroite = true;
    private GameObject manager;
    private float attackCooldown;

    private void Start()
    {
		player = GameObject.Find ("Player");
		source = player.GetComponent<AudioSource> ();
        manager = GameObject.Find("Manager");
        attackCooldown = attackCooldownStatic;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag=="Player")
        {
            if (attackCooldown <= 0)
            {
				source.PlayOneShot (music);
                manager.GetComponent<GameLeading>().chrono -= damage;
                attackCooldown = attackCooldownStatic;
            }
        }
    }
    private void FixedUpdate()
    {
        if(attackCooldown>0)
        {
            attackCooldown -= Time.deltaTime;
        }

        if(this.transform.position.x >= xMax-0.1 && this.transform.position.x <= xMax + 0.1)
        {
            directionDroite = false;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (this.transform.position.x >= xMin-0.1 && this.transform.position.x <= xMin + 0.1)
        {
            directionDroite = true;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (directionDroite)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
    }
}
