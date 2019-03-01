using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Capacities
{
    [SerializeField] GameObject groundCheck;
    [SerializeField] GameObject biosRoom;
    [SerializeField] private LayerMask layer;
    [SerializeField] float speed;
    [SerializeField] float speedJump;
    [SerializeField] float radiusCircle;


    public bool touchGround, shrinked;
    public int knowledge = 0;

    private Rigidbody2D rigibody2D;
    private GameLeading gameLeading;
    private float directionX, timerShrink = 0f;
    //private AudioSource AudioPlayer;
    //private AudioClip[] clips

    void Start()
    {
        Initialization();
        rigibody2D = this.GetComponent<Rigidbody2D>();
        gameLeading = GameObject.Find("Manager").GetComponent<GameLeading>();
        //AudioPlayer = this.GetComponent<AudioSource>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //AudioPlayer.clip = clips[2];
        //AudioPlayer.Play();
		if (skills[(int)Skill.ghost] && collision.gameObject.tag == "GhostWall")
        {
            collision.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
		}
		if (skills[(int)Skill.openDoor] && Input.GetAxisRaw ("OpenDoor") == 1 && collision.gameObject.tag == "Door")
        {
            collision.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
		}
		if (!touchGround)
        {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
		}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag=="Bios")
        {
            //AudioPlayer.Play();
            gameLeading.timeFreezing = true;
            gameLeading.chrono = gameLeading.chronoStatic;
            gameLeading.knowledge += this.knowledge;
            this.knowledge = 0;
            foreach (GameObject neurone in gameLeading.ObjetTemporaire)
            {
                neurone.GetComponent<Neuronne>().takeAndSave = true;
            }
            gameLeading.ObjetTemporaire = new List<GameObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bios")
        {
            gameLeading.timeFreezing = false;
        }
    }

    void FixedUpdate ()
    {
        touchGround = Physics2D.OverlapCircle(groundCheck.transform.position, radiusCircle, layer);
        directionX = Input.GetAxisRaw("Horizontal");
        if (directionX == -1)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            this.GetComponent<Animator>().SetTrigger("isWalking");
        }
        else if (directionX == 1)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            this.GetComponent<Animator>().SetTrigger("isWalking");
        }
        else
        {
            this.GetComponent<Animator>().SetTrigger("NotMooving");
        }
        WalkAndRun();
        Jump();
        Shrink();

	}

    private void WalkAndRun()
    {
        //run
        if (skills[(int)Skill.run] && Input.GetAxisRaw("Run") == 1)
        {
            rigibody2D.velocity = new Vector2(directionX * Time.deltaTime * (speed * 2f), rigibody2D.velocity.y);
        }
        //marche
        else
        {
            rigibody2D.velocity = new Vector2(directionX * Time.deltaTime * speed, rigibody2D.velocity.y);
        }
    }
    private void Jump()
    {
        if (Input.GetAxisRaw("Jump") == 1)
        {
            if (touchGround)
        	{
                rigibody2D.AddForce(new Vector2(0f, 1f) * Time.deltaTime * speedJump, ForceMode2D.Impulse);
            }
        }
    }

    private void Shrink()
    {
        if (timerShrink > 0)
            timerShrink -= Time.deltaTime;
        else if (timerShrink <= 0)
        {
            if (skills[(int)Skill.shrink] && Input.GetAxisRaw("Shrink") == 1)
            {
                if (!shrinked)
                {
                    transform.localScale = new Vector3(1f, 0.5f, 1);
                    shrinked = true;
                    timerShrink = 0.2f;
                }
                else if (shrinked)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    shrinked = false;
                    timerShrink = 0.2f;
                }
            }
        }
    }
}
