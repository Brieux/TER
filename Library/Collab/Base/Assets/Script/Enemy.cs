using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health;
	public float speed;
	public int distanceMax;
	private int dist = 0;
	private bool right = true;
	public transform transformPlayer;
	//private Animation anim;


    // Start is called before the first frame update
    void Start()
    {	
		//anim.GetComponent<Animator>();
		//anim.SetBool("isRunning", true);
		
    }

    // Update is called once per frame
    void Update()
    {	
		if ((transformPlayerlayer.x-transform.x) <= 30){
			transform.Translate(Vector2.right * speed+speed * Time.deltaTime);
		}
		if(health <= 0)
		{
			Destroy(gameObject);
		}
		if (dist == distanceMax){
			right = !right;
		}
		if (dist == -distanceMax){
			right = !right;
		}
		dist = Patrouille(dist, right);
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
		health -= damage;
		Debug.Log("damage TAKEN !");
	}
}
