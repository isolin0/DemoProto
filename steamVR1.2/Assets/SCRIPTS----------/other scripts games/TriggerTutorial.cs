//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerTutorial : MonoBehaviour {

	public GameObject Darwin;
	private bool triggered = false;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!triggered)
		{
			Darwin.SendMessage("TriggerThisDialog", (7));
			triggered = true;
		}
		
	}

	public void TriggerThisDialog()
	{
		if (!triggered)
		{
			Darwin.SendMessage("TriggerThisDialog", (8));
			triggered = true;
		}
		
	}

}