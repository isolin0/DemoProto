using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
	public Camera cam;
	public Light[] lightsSegundoPlano;
	public Light[] lightsDispositivo;
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

			foreach (var light in lightsSegundoPlano)
			{
				light.gameObject.SetActive(true);
			}
			foreach (var light_ in lightsDispositivo)
			{
				light_.gameObject.SetActive(false);
			}
		}

	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Devise")
		{
			
			cam.cullingMask = standerMask;
			conDisp.SetActive(false);
			foreach (var light in lightsSegundoPlano)
			{
				light.gameObject.SetActive(false);
			}
			foreach (var light_ in lightsDispositivo)
			{
				light_.gameObject.SetActive(true);
			}
		}
	}

}
