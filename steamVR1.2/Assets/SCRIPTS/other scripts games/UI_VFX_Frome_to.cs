//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UI_VFX_Frome_to : MonoBehaviour {

	public GameObject clickedVFX;
	public GameObject glowVFX;
	public GameObject UIvfx;
	public GameObject origin;
	public GameObject destination;
	public iTween.EaseType easeType;
	public float time;
	public float rate;
	public float amount;
	public Vector3 offset;



	public void SpawnClickedVFX()
	{
		if(clickedVFX != null)
		{
			var vfx = Instantiate(clickedVFX, origin.transform.position, Quaternion.identity) as GameObject;
			vfx.transform.SetParent(origin.transform);
			var ps = vfx.GetComponent<ParticleSystem>();
			Destroy(vfx, 1);
		}
		// 

	}

	public void FromTo()
	{
		StopAllCoroutines();
		StartCoroutine(FromToCo());
	}

	IEnumerator FromToCo()
	{
		for (int i = 0; i < amount; i++)
		{
			var vfx = Instantiate(UIvfx, origin.transform.position, Quaternion.identity) as GameObject;
			vfx.transform.SetParent(origin.transform);
			iTween.MoveTo(vfx, iTween.Hash("position", destination.transform.position + offset, "easetype", easeType, "ignoretimescale", true, "time", time));
			Destroy(vfx, time + 0.5f);
			yield return new WaitForSeconds(rate);


		}
	}
	
	
}