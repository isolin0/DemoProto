//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DontDestroy : MonoBehaviour {



	private static bool created = false;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}


}