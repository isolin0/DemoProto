//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lupaBlade : MonoBehaviour {

	
	public float minCuttingVelocity = .001f;

	bool isCutting = false;
	public Transform target;

	Vector2 previousPosition;
	Vector2 startPosition;

	

	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public Camera cam;
	


	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			StartCutting();
			
		}
		else if (Input.GetMouseButtonUp(1))
		{
			StopCutting();
			
		}

		if (isCutting)
		{
			UpdateCut();
		}

	}

	void UpdateCut()
	{
		Vector2 newPosition = cam.ScreenToWorldPoint(target.position);
		rb.position = newPosition;
		previousPosition = newPosition;
	}

	void StartCutting()
	{
		startPosition = transform.position;
		isCutting = true;
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
	
	}

	void StopCutting()
	{
		transform.position = startPosition;
		isCutting = false;
	}



}