using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soin : MonoBehaviour
{
	public int nbSouls;
	public int maxSouls;
	public GameObject Player;
	public TextMesh soulsText;
	public Transform ProgressBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {	
		ProgressBarRenderer(nbSouls);
		soulsText.text = nbSouls.ToString();
		if (nbSouls > maxSouls){nbSouls = maxSouls;}
		float modifier;
        if (Input.GetKey(KeyCode.A)){
			//print("Soin");
			if (nbSouls == maxSouls){
				modifier = 4;
			} else {
				if (nbSouls <= 9 && nbSouls >= 6){
					modifier = 2;
				}
				else {
					modifier = 1;
				}
			}
		float healthBeforeHeal = Player.GetComponentInChildren<StatJoueur>().health;
		float maxHealth = Player.GetComponentInChildren<StatJoueur>().healthMax;
		//print(healthBeforeHeal);
		float newHealth = healthBeforeHeal += nbSouls * modifier;
		print (newHealth);
		if (newHealth > maxHealth){newHealth = maxHealth;} 
		Player.GetComponentInChildren<StatJoueur>().health = newHealth;
		nbSouls = 0;
		}
	}
	
	public void ProgressBarRenderer(float n){
		Vector3 sc = transform.localScale;
		sc.x = n/(10f/0.95f);
		sc.y = 0.55f;
		sc.z = 1f;
		ProgressBar.localScale = sc;
	}
	public void addSouls(int nb){
			nbSouls += nb;
	}
}
