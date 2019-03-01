using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDoor : MonoBehaviour
{
	[SerializeField] Vector2 destination;


	private void Start ()
    {
		destination.x += GetComponentInParent<Rigidbody2D> ().position.x;
		destination.y = GetComponentInParent<Rigidbody2D> ().position.y;
	}

    private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().position = destination;
        }
    }
}
