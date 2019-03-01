using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

	public void ChangerMenu(int scenename)
	{
		SceneManager.LoadScene(scenename);
	}

	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Game is exiting");
	}
}