//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetDamage : MonoBehaviour {

	private int damage;
	private TargetHit[] targets;
	public Animator anim;

	private void Start()
	{
		targets = FindObjectsOfType<TargetHit>();

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Lupa")
		{
			foreach (var target in targets)
			{
				if (!target.colliderBool)
				{
					target.TakeDamage(1);
					StartCoroutine(StartDestroy());
					anim.SetTrigger("hit");
					
					
				}
			}
		}
	}

	

	IEnumerator StartDestroy()
	{
		yield return new WaitForSeconds(.2f);
		foreach (var target in targets)
		{
			if (!target.colliderBool)
			{
				target.Spawn();

			}
		}
		
		Destroy(gameObject);
		yield return null;
	}

	public void DestroyThisObject()
	{
		Destroy(this.gameObject);
	}

	

}