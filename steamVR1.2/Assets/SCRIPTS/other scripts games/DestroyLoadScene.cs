using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void CallDestroy()
    {
		GameObject loadScreen = GameObject.FindGameObjectWithTag("loadScreen");
		Destroy(loadScreen);
		Destroy(this.gameObject);
    }

   
}
