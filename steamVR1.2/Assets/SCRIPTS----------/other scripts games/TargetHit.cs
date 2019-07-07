//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetHit : MonoBehaviour {



	
	public int startLife = 5;
	
	private int damages = 0;

	public GameObject targetPrefab;

	public GameObject progressBarPrefab;
	private GameObject proBar;
	
	
	Rigidbody2D rb;

	
	
	
	private GameObject pbarCanvas;

	public Transform[] positions;
	public CircleCollider2D circleCollider;
	public bool colliderBool = true;

	public GameObject triggerOut;
	public CircleCollider2D triggerOutCol;

	private TargetDamage[] targetDamage;

	public ItemPickUp itemPickup;

	public GameObject targetSprite;

	private void Start()
	{
		
		pbarCanvas = GameObject.FindGameObjectWithTag("uiCanvas");
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Lupa")
		{
			damages = 0;
			startLife = 5;
			circleCollider.enabled = false;
			colliderBool = false;
			proBar = Instantiate(progressBarPrefab, pbarCanvas.transform);
			proBar.GetComponent<Slider>().value = damages;
			targetSprite.SetActive(false);
			triggerOutCol.enabled = true;
			Spawn();
			
		}
	}

	public void Spawn()
	{
		int randomNumber = Random.Range(0, positions.Length);

		Instantiate(targetPrefab, positions[randomNumber].position, Quaternion.identity, this.transform);
		
		
	}

	public void TakeDamage(int damage_)
	{
		damages += damage_;
		proBar.GetComponent<Slider>().value = damages;
	


		if (startLife <= damages)
		{
			Destroy(proBar);
			this.gameObject.SendMessage("OnClick");
			Destroy(this.gameObject);
			
		}
			

		
	}

	public void ResetVars()
	{
		targetSprite.SetActive(true);
		damages = 0;
		startLife = 5;
		circleCollider.enabled = true;
		triggerOutCol.enabled = false;
		colliderBool = true;
		proBar.GetComponent<Slider>().value = damages;
		Destroy(proBar);

		Component[] targetDamages;

		targetDamages = GetComponentsInChildren(typeof(TargetDamage));

		if (targetDamages != null)
		{
			foreach (TargetDamage target in targetDamages)
					target.DestroyThisObject();

		}


	}




}