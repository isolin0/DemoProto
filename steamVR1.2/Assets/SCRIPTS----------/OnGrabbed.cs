using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class OnGrabbed : MonoBehaviour
{

	public Collider col;
    // Start is called before the first frame update
    void Start()
    {
		col = GetComponent<BoxCollider>();

		if (GetComponent<VRTK_InteractableObject>() == null)

		{

			Debug.LogError("Team3_Interactable_Object_Extension is required to be attached to an Object that has the VRTK_InteractableObject script attached to it");

			return;

		}



		//subscribe to the event.  NOTE: the "ObectGrabbed"  this is the procedure to invoke if this objectis grabbed.. 

		GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);

		GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(ObjectUnGrabbed);

	}

	private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)

	{

		col.enabled = false;

	}

	private void ObjectUnGrabbed(object sender, InteractableObjectEventArgs e)

	{
		col.enabled = true;
	}


	

}
