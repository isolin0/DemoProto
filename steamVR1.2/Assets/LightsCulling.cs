using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsCulling : MonoBehaviour
{
	public Light[] segundoPlanoLights;

	
	
	void OnPreCull()
	{
		foreach (var light in segundoPlanoLights)
		{
			if (light != null)
				light.enabled = false;
		}
		
	}
	
	void OnPreRender()
	{
		foreach (var light in segundoPlanoLights)
		{
			if (light != null)
				light.enabled = false;
		}
		
	}
	void OnPostRender()
	{
		foreach (var light in segundoPlanoLights)
		{
			if (light != null)
				light.enabled = true;
		}
	}
}
	