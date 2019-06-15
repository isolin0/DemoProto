using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour {

	public SlotInfo slotinfo;
	public Image itemImage;
	public Text itemTitle;
	//public RawImage lockImage;
	public Text amountText;
	public ItemDataBase itemDataBase;

	private GameObject floraInventory;
	private GameObject faunaInventory;
	private GameObject diarioInventory;
	private GameObject itemsInventory;

	private void Start()
	{
		floraInventory = GameObject.Find("Flora_Manager");
		faunaInventory = GameObject.Find("Fauna_Manager");
		diarioInventory = GameObject.Find("Diario_Manager");
		itemsInventory = GameObject.Find("Items_Manager");
	}
	public void Update()
	{
		UpdateUI();



	}


	public void SetUp(int id)
	{
		slotinfo = new SlotInfo();
		slotinfo.id = id;
		slotinfo.EmptySlot();
	}

	public void UpdateUI()// esta funcion nos va a permitir actualizar la cantidad eh imagen que se almacena en un slot
	{
		if (slotinfo != null && slotinfo.isEmpty)
		{
			 itemImage.sprite = null;
			//itemImage.sprite = itemDataBase.FindItemInItemDataBase(slotinfo.id).itemImage;
			//itemTitle.text = itemDataBase.FindItemInItemDataBase(slotinfo.id).title;
			itemImage.enabled = false;
			//lockImage.enabled = true;


		}
		else
		{
			itemImage.sprite = itemDataBase.FindItemInItemDataBase(slotinfo.itemId).itemImage;
			itemTitle.text = itemDataBase.FindItemInItemDataBase(slotinfo.itemId).title;
			 itemImage.enabled = true;
			//lockImage.enabled = false;
			if (slotinfo.amount > 1)
			{
				amountText.text = slotinfo.amount.ToString();
				amountText.gameObject.SetActive(true);

			}
			else
				amountText.gameObject.SetActive(false);

		}
	}


	public void TriggerDescription()
	{
		
		if (itemDataBase.FindItemInItemDataBase(slotinfo.itemId).isFlora == true)
		{
			floraInventory.GetComponent<FFInfoManager>().StartDescription(slotinfo.itemId);
		}
		else if (itemDataBase.FindItemInItemDataBase(slotinfo.itemId).isFauna == true)
		{
			faunaInventory.GetComponent<FFInfoManager>().StartDescription(slotinfo.itemId);
		}
		else if (itemDataBase.FindItemInItemDataBase(slotinfo.itemId).isDiario == true)
		{
			diarioInventory.GetComponent<FFInfoManager>().StartDescription(slotinfo.itemId);
		}
		else
		{
			itemsInventory.GetComponent<FFInfoManager>().StartDescription(slotinfo.itemId);
		}
	}
		/*
		{
            FindObjectOfType<ItemInfoManager>().StartDescription(slotinfo.itemId);
        }*/
	
    public void ItemRemove()
    {
        FindObjectOfType<Inventory>().RemoveItem(slotinfo.itemId);
        
    }


}
/*
[System.Serializable]
public class SlotInfo
{
    public int id;
    public bool isEmpty = true;
    public int itemId;
	public string itemTitle;
    public int amount;
    public int MaxAmount = 1;

    public void EmptySlot()
    {
        isEmpty = true;
        amount = 0;
        itemId = -1;
		itemTitle = "";
    }
}*/
