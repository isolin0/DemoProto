using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		//Ignore the collisions between layer 0 (default) and layer 8 (custom layer you set in Inspector window)
		Physics.IgnoreLayerCollision(0, 2);
	}

    
}
