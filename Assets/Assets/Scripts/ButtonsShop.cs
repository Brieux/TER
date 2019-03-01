using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsShop : MonoBehaviour
{
    [SerializeField] Sprite button;

    private GameObject[] listShop;

	void Start ()
    {
        listShop = new GameObject[11];

        for (int i = 0; i < 11; i++)
        {
			listShop [i] = new GameObject ();
			listShop [i].AddComponent<Image> ();
			listShop [i].GetComponent<Image> ().sprite = button;
			listShop [i].AddComponent<Button> ();
//			listShop [i].AddComponent<CanvasRenderer> ();
			listShop [i].transform.position = new Vector3 (0f, 450f - 55f * i, 0);
			listShop [i].AddComponent<DisplayShop> ();
			GameObject Name = new GameObject();
			Name.AddComponent<Text> ();
			Name.transform.parent = listShop [i].transform;
		}
	}
}
