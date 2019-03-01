using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J2Controller : MonoBehaviour
{
	public Transform mainCam;

	private float mainx;
	private float mainxe;
	private float mainy;
	private float mainye;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		Mouvement();

	}

	void Mouvement()
	{
		mainx = mainCam.position.x + 9f;
		mainxe = mainCam.position.x - 9f;
		mainy = mainCam.position.x + 4f;
		mainye = mainCam.position.x - 6.9f;


		if (Input.GetKey(KeyCode.M))
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector3(0, 0, 0);
		}

		if (Input.GetKey(KeyCode.K))
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector3(0, 0, 180);
		}

		if (Input.GetKey(KeyCode.O))
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector3(0, 0, 90);
		}

		if (Input.GetKey(KeyCode.L))
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector3(0, 0, -90);
		}

		if (transform.position.x > mainx)
		{
			var pos = transform.position;
			pos.x = mainxe;
			transform.position = pos;
		}

		if (transform.position.x < mainxe)
		{
			var pos = transform.position;
			pos.x = mainx;
			transform.position = pos;
		}

		if (transform.position.y > mainy)
		{
			var pos = transform.position;
			pos.y = mainye;
			transform.position = pos;
		}

		if (transform.position.y < mainye)
		{
			var pos = transform.position;
			pos.y = mainy;
			transform.position = pos;
		}

	}

}
