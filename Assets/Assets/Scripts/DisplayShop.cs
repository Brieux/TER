using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayShop : MonoBehaviour
{
    [SerializeField] int index;
    private PlayerController playerController;

	public int Index{ get { return index; } }

	void Start ()
    {
		playerController = GameObject.Find ("Player").GetComponent<PlayerController>();
	}
	
	void Update ()
    {
		this.GetComponentsInChildren<Text>()[0].text = playerController.nameSkill[index];
		this.GetComponentsInChildren<Text>()[1].text = playerController.description[index];
		this.GetComponentsInChildren<Text>()[2].text = playerController.prix[index].ToString();
	}
}
