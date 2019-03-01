using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatJoueur : MonoBehaviour
{
    public int health;
    public bool protection;
    public Transform transformLight;
    public float rangeProtection;
    private float distanceToLight;
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
	if(Vector3.Distance(transform.position, transform.transformLight)< rangeProtection){
		protection = true;
	}
    }

    void TakeDamage(int d)
    {
        health -= d;

    }
}
