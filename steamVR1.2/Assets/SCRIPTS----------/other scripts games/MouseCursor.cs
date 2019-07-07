using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour
{
	//public SpriteRenderer rend;
	//public Image image_;
	public GameObject normalCursor;
	public GameObject LupaCursor;
	
	//public GameObject ClickEffect;

    void Start()
    {
		Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
		//Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 cursorPos = Input.mousePosition;
		transform.position = cursorPos;

		if (Input.GetMouseButtonDown(1))
		{
			LupaCursor.SetActive(true);
			normalCursor.SetActive(false);
			
			//rend.sprite = LupaCursor;
		} else if (Input.GetMouseButtonUp(1))
		{
			//rend.sprite = normalCursor;
			LupaCursor.SetActive(false);
			normalCursor.SetActive(true);
			
		}

		if (Input.GetMouseButtonDown(0))
		{
			//Instantiate(ClickEffect, transform.position, Quaternion.identity);
		}
		
	}
}
