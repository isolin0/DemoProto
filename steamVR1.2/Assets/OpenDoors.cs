using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OpenDoors : MonoBehaviour
{
	// Start is called before the first frame update
	public Rigidbody rb;
	// Set the hinge limits for a door.
	public HingeJoint hinge;
	bool grabed = false;
	float jAngle;
	void Start()
    {
		hinge = GetComponent<HingeJoint>();
		
		rb.GetComponent<Rigidbody>();

		if (GetComponent<VRTK_InteractableObject>() == null)

		{

			Debug.LogError("Team3_Interactable_Object_Extension is required to be attached to an Object that has the VRTK_InteractableObject script attached to it");

			return;

		}



		//subscribe to the event.  NOTE: the "ObectGrabbed"  this is the procedure to invoke if this objectis grabbed.. 

		GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);

		GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(ObjectUnGrabbed);
	}
	private void Update()
	{
		jAngle = hinge.angle;
		if(grabed && jAngle <= -90)
		{
			rb.isKinematic = false;
			
		}

	}

	private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
	{
		grabed = true;
	
		/*JointLimits limits = hinge.limits;
		if (hinge.angle >= 4)
			Debug.Log("limite alcanzado");*/
	//	rb.isKinematic = false;


	}

	private void ObjectUnGrabbed(object sender, InteractableObjectEventArgs e)
	{
		grabed = false;
		

	}
}
