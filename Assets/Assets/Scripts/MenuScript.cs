using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Credit;
    [SerializeField] GameObject Controle;

    private bool credit = false;
    private bool controle = false;

    private void Awake()
    {
        Credit.SetActive(false);
        Controle.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Credits()
    {
        Menu.SetActive(false);
        Credit.SetActive(true);
        credit = true;
    }

    public void OurControle()
    {
        Menu.SetActive(false);
        Controle.SetActive(true);
        controle = true;
    }

    private void FixedUpdate()
    {
        if(credit)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Credit.SetActive(false);
                Menu.SetActive(true);
                credit = false;
            }
        }

        if (controle)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Controle.SetActive(false);
                Menu.SetActive(true);
                controle = false;
            }
        }
    }

}
