using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeStuck : MonoBehaviour
{
	public Rigidbody rb;
	private bool stuck = false;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "KnifeStuck")
		{
			//rb.isKinematic = true;
			//rb.velocity = Vector3.zero;
			rb.constraints = RigidbodyConstraints.FreezeAll;
			//rb.constraints = RigidbodyConstraints.None;

			stuck = true;
		}

		if (stuck)
		{
			rb.constraints = RigidbodyConstraints.None;
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "KnifeStuck")
		{
			//rb.isKinematic = true;
			//rb.velocity = Vector3.zero;
			//rb.constraints = RigidbodyConstraints.FreezeAll;
			rb.constraints = RigidbodyConstraints.None;
			//VRTK.intera
		}
	}
}
