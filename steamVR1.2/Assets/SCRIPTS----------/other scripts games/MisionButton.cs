//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MisionButton : MonoBehaviour {


	public string misionTitle;
	[TextArea(3, 10)]
	public string misionText;
	public GameObject misionManager;

	public void StartMisionDescription()
	{
		misionManager.GetComponent<MisionsManager>().GetMisionTitle(misionTitle);
		misionManager.GetComponent<MisionsManager>().GetMisionDescription(misionText);
	}


}