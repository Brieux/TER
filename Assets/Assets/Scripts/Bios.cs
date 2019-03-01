using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bios : MonoBehaviour
{
    [SerializeField] GameObject listShop;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag=="Player")
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                if(listShop.active)
                {
                    listShop.SetActive(false);
                }
                else
                {
                    listShop.SetActive(true);
                }
            }
        }
    }
}
