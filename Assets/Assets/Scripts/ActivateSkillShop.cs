using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateSkillShop : MonoBehaviour {

	private PlayerController playerController;
    private GameLeading gameLeading;
	private int index;

	void Start ()
    {
		playerController = GameObject.Find ("Player").GetComponent<PlayerController>();
        gameLeading = GameObject.Find("Manager").GetComponent<GameLeading>();
        index = GetComponent<DisplayShop>().Index;
    }

	public void Buy()
    {
        //Si le joueur a assez de knowledge pour acheter le skill
		if (gameLeading.knowledge - playerController.prix [index] > 0)
        {
            gameLeading.knowledge -= playerController.prix [index]; //Réduction du nombre de knowledge
            playerController.skills [index] = true; //Skill mis à true
			this.enabled = false;
		}
	}
}
