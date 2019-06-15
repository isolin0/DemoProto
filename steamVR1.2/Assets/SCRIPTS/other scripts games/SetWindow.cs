using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetWindow : MonoBehaviour {

    //public Animator anim;
    public int itemId;
   // public GameObject itemInventory;
   // public GameObject floraInventory;
	//public GameObject faunaInventory;
	//public GameObject diarioInventory;
	public ItemDataBase dataBase;
	//private enum Itemtype {FF};

	public Text nameText;
	public Image image;
	public Text description;

	

        
	public void SetWindowActive()
	{
		this.gameObject.SetActive(true);
	}
	
    
    public void SetItemID(int id)
    {
        itemId = id;
        
    }

    public void AddThisItem()
    {
        
        if (dataBase.FindItemInItemDataBase(itemId).isFlora==true)
        {
			FindObjectOfType<FFInventory>().AddItem(itemId);
		

		}
		else if (dataBase.FindItemInItemDataBase(itemId).isFauna == true)
		{
			FindObjectOfType<FaunaInventory>().AddItem(itemId);
			
			
			


		}
		else if (dataBase.FindItemInItemDataBase(itemId).isDiario == true)
		{
			FindObjectOfType<DiarioInventory>().AddItem(itemId);
			
			
		}
        else
        {
			FindObjectOfType<Inventory>().AddItem(itemId);
			
		}
		
	}
}
