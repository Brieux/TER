using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float health;
	public float maxHealth;

	public float speed;
	public int distanceMax;
	private int dist = 0;
	private bool right = true;

	public Transform transformPlayer;
	public float rangedetection;
    public int damage = 10;
	
	private float timeBtwAttack;
	public float startTimeBtwAttack;
	
	public Transform attackPos;
    public LayerMask isPlayer;
	public float attackRange;
	public Transform lowLife;
	public TextMesh pdvText;
	
	public GameObject J2;
	public GameObject J1;
	//private Animation anim;


    // Start is called before the first frame update
    void Start()
    {	
		//anim.GetComponent<Animator>();
		//anim.SetBool("isRunning", true);
			maxHealth = health;

    }

    // Update is called once per frame
    void Update()
    {
		if (health <= 0)
		{
			Destroy(gameObject);
			J1.GetComponent<Soin>().addSouls(1);
			if (Vector3.Distance(J2.transform.position, transform.position) <= J2.GetComponentInChildren<Light>().range/2){
				//J1.scoring(true);
				J1.GetComponent<StatJoueur>().scoring(true);
			}
			else{
				J1.GetComponent<StatJoueur>().scoring(false);
			}
		}
		UpdateBar(lowLife);
		pdvText.text = health.ToString();
		float distanceToTarget = Vector3.Distance(transform.position, transformPlayer.position);
		detectionJoueur(distanceToTarget);
		
        if (timeBtwAttack <= 0) {
            if (distanceToTarget <= attackRange)
            {
                Collider2D player = Physics2D.OverlapCircle(attackPos.position, attackRange, isPlayer);
				//for(int i=0; i< player.Length;i++){
					player.GetComponent<StatJoueur>().TakeDamage(damage);
				//}
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
	void detectionJoueur(float distanceToTarget){
	
		if (distanceToTarget < rangedetection){
			transform.position = Vector2.MoveTowards(transform.position, transformPlayer.position, speed * Time.deltaTime);
		}
		else
		{
			dist = Patrouille(dist, right);
		}
		if (dist == distanceMax){
			right = !right;
		}
		if (dist == -distanceMax){
			right = !right;
		}
	}
	
    int Patrouille(int dist, bool dir)
		{
		if (dir)
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			dist = dist + 1;
		}
		else
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);
			dist = dist -1;
		}
		return dist;
    }

	public void TakeDamage(int damage)
	{
		print(damage);
		health -= damage;
		Debug.Log("damage TAKEN !");
	}

	public void UpdateBar(Transform lowLife){
		
		Vector3 newScale = transform.localScale;
		Vector3 newPos = transform.localPosition;
		newScale.x = 1f-health/maxHealth; //a modifier avec toute les valeurs de point de vie
		newScale.y = 1;
		newScale.z = 1.04f;
		newPos.x = (health/maxHealth)/2f;
		newPos.y = 0;
		newPos.z = 0;
		lowLife.localScale = newScale;
		lowLife.localPosition = newPos;
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, rangedetection);
		Gizmos.DrawWireSphere(attackPos.position, attackRange);
	}
}
