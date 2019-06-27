using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class LayerChange : MonoBehaviour
{

	public GameObject parent;
	public bool changeOnStart = false;
	void Start()

	{
		if (changeOnStart)
			ChangeLayer();

		//make sure the object has the VRTK script attached... 

		if (GetComponent<VRTK_InteractableObject>() == null)

		{

			Debug.LogError("Team3_Interactable_Object_Extension is required to be attached to an Object that has the VRTK_InteractableObject script attached to it");

			return;

		}



		//subscribe to the event.  NOTE: the "ObectGrabbed"  this is the procedure to invoke if this objectis grabbed.. 

		GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);

		//GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(ObjectUnGrabbed);




	}
	private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)

	{
		SetLayerRecursively(parent, 0);
		
	}

	public void ChangeLayer()
	{
		SetLayerRecursively(parent, 0);
	}
	

  public static void SetLayerRecursively(GameObject go, int layerNumber)
    {
		//Debug.Log("enter set layer");
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
		
    }


}
