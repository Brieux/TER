using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuronne : MonoBehaviour
{
    private GameLeading gameLeading;
    public bool takeAndSave = false;

    public int skillPoints = 0;

    private void Start()
    {
        gameLeading = GameObject.Find("Manager").GetComponent<GameLeading>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            gameLeading.ObjetTemporaire.Add(this.gameObject);
            collision.gameObject.GetComponent<PlayerController>().knowledge += skillPoints;
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (takeAndSave == true)
        {
            Destroy(this);
        }
    }
}
