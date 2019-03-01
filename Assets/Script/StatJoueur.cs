using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatJoueur : MonoBehaviour
{
    public float health;
	public float healthMax = 100;
    public bool protection;
    public Transform CharacterJ2Light;
    public float rangeProtection;
    private float distanceToLight;
    public Light J2Light;
	public float maxRange;
	public int score;
	public TextMesh scoreText;

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
		
		UpdateLightRange(J2Light);
		UpdateScore();
		rangeProtection = (J2Light.range)/2;	
		if(Vector3.Distance(transform.position, CharacterJ2Light.position)<= rangeProtection){
			protection = true;
		}
		else{
			protection = false;
		}
    }
	public void UpdateScore(){
		scoreText.text = score.ToString();
	}
	
	public void UpdateLightRange(Light J2Light){
		J2Light.range = maxRange/(100/health);
		//print(J2Light.range);
	}
	
    public void TakeDamage(int d)
    {
	if (protection){
	        health -= d;
	}
	else {
		health = 0;
	}
	}
	
	public void scoring(bool EnnemyInLight){
		if (protection == true){
			score = score +50;
		}else {if (EnnemyInLight == true){
			score = score +75;
			}
			else{
				score = score +100;
			}
		}
    }
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(CharacterJ2Light.position, rangeProtection);
	}
}
