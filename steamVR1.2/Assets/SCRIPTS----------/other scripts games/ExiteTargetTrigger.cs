//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExiteTargetTrigger : MonoBehaviour {


	public GameObject parent;
	

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Lupa")
		{
			parent.SendMessage("ResetVars");
			
		}
			
	}


}