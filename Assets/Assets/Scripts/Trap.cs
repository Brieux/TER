using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] Vector2 distance;
    private Vector2 position;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                position = new Vector2(player.transform.position.x + distance.x, player.transform.position.y + distance.y);
                player.GetComponent<Rigidbody2D>().position = position;
            }
        }
    }
}
