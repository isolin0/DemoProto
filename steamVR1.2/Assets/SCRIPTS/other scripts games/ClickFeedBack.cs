using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFeedBack : MonoBehaviour {


	public GameObject fbPrefab;

	public GameObject parentObj;
	Vector3 mousePos;

	private void Update()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit) && hit.transform.tag=="Nothing")
		{
			
			Transform objectHit = hit.transform;

		}

	}
	public void FeedBack()
	{
		
		
		mousePos.z = 2.0f;       // we want 2m away from the cawomera position
		var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
		GameObject vfx = Instantiate(fbPrefab, objectPos, Quaternion.identity);
		vfx.transform.SetParent(parentObj.transform, false);


	}
}
