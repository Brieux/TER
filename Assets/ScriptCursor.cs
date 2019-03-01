using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCursor : MonoBehaviour
{
  void Start()
  {
  }
    public bool col;
    void OnCollisionStay2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Ground"){
        col = true;
        print("Grounded");
      }
      else
      {
        print("NotGrounded");
        col = false;
      }
    }
}
