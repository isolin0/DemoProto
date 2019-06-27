using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public void RotateLeft()
	{
		this.transform.Rotate(0, -90f, 0);
	}

	public void RotateRight()
	{
		this.transform.Rotate(0, 90f, 0);
	}


}
