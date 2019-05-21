using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
	public Camera cam;
	public GameObject conDisp;

	int standerMask;

	private void Start()
	{
		standerMask = cam.cullingMask;
	}

	private void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Devise")
		{
			cam.cullingMask = (1 << 0) | (1 << 8);
			conDisp.SetActive(true);
		}

	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Devise")
		{
			cam.cullingMask = standerMask;
			conDisp.SetActive(false);
		}
	}

}
