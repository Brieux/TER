using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertically : MonoBehaviour
{
	[SerializeField] float yMin, yMax;
	[SerializeField] float length = 1f;
    [SerializeField] float timerWait = 1f;

    private Rigidbody2D rigibody2D;
	private bool moveUp = false;

	void Start ()
    {
		Physics2D.IgnoreLayerCollision (8, 8, true);
		Physics2D.IgnoreLayerCollision (8, 9, true);
        rigibody2D = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate ()
    {

		if (rigibody2D.position.y <= yMin && !moveUp)
        {
			if (timerWait > 0)
            {
                rigibody2D.velocity = new Vector2 (0, 0);
				timerWait -= Time.deltaTime;
			}
			else
            {
				moveUp = true;
				timerWait = length;
			}
				
		}
        else if (rigibody2D.position.y >= yMax && moveUp)
        {
			if (timerWait > 0)
            {
                rigibody2D.velocity = new Vector2 (0, 0);
				timerWait -= Time.deltaTime;
			}
            else
            {
				moveUp = false;
				timerWait = length;
			}
		}
        else
        {
            if (moveUp)
            {
                rigibody2D.velocity = new Vector2(rigibody2D.velocity.x, 100 * Time.deltaTime);
            }
            else
            {
                rigibody2D.velocity = new Vector2(rigibody2D.velocity.x, 100 * Time.deltaTime * -1);
            }
		}
	}
}
