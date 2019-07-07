using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemPickUp : MonoBehaviour {


    public bool recolectable;
	public bool isFF;
	public bool isFauna;
	public bool isDiario;

    public int itemID;

	//private UIGameManager uiManager;

	private bool clickedAnim = false;
	//public GameObject lupaParticles;
	//public GameObject lupaGo;

	public bool collected = false;

   

	// Use this for initialization
	void Start () {
		//uiManager = FindObjectOfType<UIGameManager>();
		//uiManager = GetComponent<UIGameManager>();
	}
	
	public void OnClick()
    {
		

		if (recolectable)
		{
			
				clickedAnim = false;
		///	uiManager.SetPickUpWindow(itemID);
			//uiManager.pickupItem = this.gameObject;
				FindObjectOfType<UIGameManager>().SetPickUpWindow(itemID);
				FindObjectOfType<UIGameManager>().pickupItem = this.gameObject;
			
			
			
		}
			

		if (isFF)
		{
			FindObjectOfType<UIGameManager>().SetFFWindow(itemID);
		//	uiManager.SetFFWindow(itemID);
			
				
		}
			

		if (isFauna)
		{
			FindObjectOfType<UIGameManager>().SetFaunaWindow(itemID);
			//uiManager.SetFaunaWindow(itemID);
		}
			

		if (isDiario)
		{
			FindObjectOfType<UIGameManager>().SetDiarioPageWindow(itemID);
			//uiManager.SetDiarioPageWindow(itemID);
		}
			



	}

	IEnumerator ShowAferAnim(int time)
	{
		//Animator anim = this.GetComponent<Animator>();
		//anim.SetBool("clicked", true);
		
		
		yield return new WaitForSeconds(time);
		clickedAnim = true;
		OnClick();


		yield return null;
	}

	public void SendCollected()
	{
		if (!collected)
		{
			collected = true;
			FindObjectOfType<UIGameManager>().SceneCollectables();
			//uiManager.SceneCollectables();
		}
	}

	public void SetLupasActive()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Lupa");

		foreach (GameObject go in gos)
		{
			go.SetActive(false);
		}
		
	//	lupaGo.SetActive(true);
	}

	public void DescartarPickUp()
	{
		GameObject[] items;
		items = GameObject.FindGameObjectsWithTag("pickUpItem");

		foreach (GameObject item in items)
		{
			item.GetComponent<Button>().enabled = true;
		}
	}
}
