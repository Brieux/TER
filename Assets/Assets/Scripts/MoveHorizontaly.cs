using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontaly : MonoBehaviour {

	[SerializeField] float xMin, xMax;
	[SerializeField] float length = 1f;
	[SerializeField] float timerWait = 1f;

	private Rigidbody2D rb;
	private bool moveRight = false;

	void Start ()
	{
		Physics2D.IgnoreLayerCollision (8, 8, true);
		Physics2D.IgnoreLayerCollision (8, 9, true);
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
	{

		if (rb.position.x <= xMin && !moveRight)
		{
			if (timerWait > 0)
			{
				rb.velocity = new Vector2 (0, 0);
				timerWait -= Time.deltaTime;
			}
			else
			{
				moveRight = true;
				timerWait = length;
			}

		}
		else if (rb.position.x >= xMax && moveRight)
		{
			if (timerWait > 0)
			{
				rb.velocity = new Vector2 (0, 0);
				timerWait -= Time.deltaTime;
			}
			else
			{
				moveRight = false;
				timerWait = length;
			}
		}
		else
		{
			if (moveRight)
			{
				rb.velocity = new Vector2(100 * Time.deltaTime ,rb.velocity.y);
			}
			else
			{
				rb.velocity = new Vector2(-100 * Time.deltaTime ,rb.velocity.y);
			}
		}
	}
}
