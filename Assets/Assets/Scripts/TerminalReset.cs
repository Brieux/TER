using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalReset : MonoBehaviour
{
    [SerializeField] Vector2 positionTP;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag=="Player")
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().position = positionTP;
            }
        }
    }
}
