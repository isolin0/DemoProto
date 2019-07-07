//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GostTrigger : MonoBehaviour {

	Animator anim;
	public GameObject DarwinDialog;
	
	
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		FindObjectOfType<AudioManager>().Play("BolaFantasma");
	}

	
	public void SetBoolean()
	{
		anim.SetBool("transform", true);
		StartCoroutine(OnAnimationEnd());
		FindObjectOfType<AudioManager>().Stop("BolaFantasma");
	}
	IEnumerator OnAnimationEnd()
	{
		yield return new WaitForSeconds(0.5f);
		//cacique.SetActive(true);
		DarwinDialog.GetComponent<DialogoTrigger>().TriggerDialogo();
		this.gameObject.SetActive(false);
		yield return null;
	}

	
}