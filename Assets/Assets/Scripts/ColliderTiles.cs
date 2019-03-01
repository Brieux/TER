using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTiles : MonoBehaviour
{
	[SerializeField] float x, y;

	void Start ()
    {
		GameObject son = new GameObject ();
		son.AddComponent<BoxCollider2D> ();
		son.GetComponent<BoxCollider2D> ().size = new Vector2 (x, y);
		son.transform.parent = this.transform;
		son.transform.position = new Vector3 (this.transform.position.x + x / 2,transform.position.y + y/2, 0);
		son.layer = 8;
        son.tag = this.tag; //ajout thomas
	}

	void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawCube(new Vector3 (this.transform.position.x + x/2,transform.position.y + y/2, 0), new Vector3 (x,y,1));
	}
}
