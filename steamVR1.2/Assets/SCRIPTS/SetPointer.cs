using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPointer : MonoBehaviour
{

	
	public VRTK.VRTK_Pointer L_pointer;
	public VRTK.VRTK_BezierPointerRenderer L_render;
	public VRTK.VRTK_Pointer R_pointer;
	public VRTK.VRTK_BezierPointerRenderer R_render;
	public GameObject teleportGJ;

	public bool Teleport;
	// Start is called before the first frame update
	void Start()
    {
		
		if (Teleport)
		{
			L_pointer.enabled = true;
			L_render.enabled = true;
			R_pointer.enabled = true;
			R_render.enabled = true;


		}
		else
		{
			if(teleportGJ!=null)
				teleportGJ.SetActive(false);
			L_pointer.enabled = false;
			L_render.enabled = false;
			R_pointer.enabled = false;
			R_render.enabled = false;
		}
    }

    
}
