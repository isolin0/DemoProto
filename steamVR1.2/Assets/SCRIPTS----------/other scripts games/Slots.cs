using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour {
	//IDropHandler 
	public SlotInfo slotinfo;
	public Image itemImage;
	public Text itemTitle;
	public GameObject lockImage;
	public Text amountText;
	public GameObject newVFX;
	public GameObject newItemImg;
	public ItemDataBase itemDataBase;

	

	private GameObject floraInventory;
	private GameObject faunaInventory;
	private GameObject diarioInventory;
	private GameObject itemsInventory;

	public bool itemSlot=false;
	Animator anim;
	private void Start()
	{
		floraInventory = GameObject.Find("Flora_Manager");
		faunaInventory = GameObject.Find("Fauna_Manager");
		diarioInventory = GameObject.Find("Diario_Manager");
		itemsInventory = GameObject.Find("Items_Manager");

		anim = GetComponent<Animator>();
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
		if (!itemSlot)
		{
			if (slotinfo != null && slotinfo.isEmpty)
			{
				// itemImage.sprite = null;
				itemImage.sprite = itemDataBase.FindItemInItemDataBase(slotinfo.id).itemImage;
				itemTitle.text = itemDataBase.FindItemInItemDataBase(slotinfo.id).title;
				//itemImage.enabled = false;
				lockImage.SetActive(true);


			}
			else
			{
				itemImage.sprite = itemDataBase.FindItemInItemDataBase(slotinfo.itemId).itemImage;
				itemTitle.text = itemDataBase.FindItemInItemDataBase(slotinfo.itemId).title;
				// itemImage.enabled = true;
				lockImage.SetActive(false);
				if (slotinfo.isNewItem)
				{
					newItemImg.SetActive(true);
					newVFX.SetActive(true);
				}
				else
				{
					newItemImg.SetActive(false);
					newVFX.SetActive(false);
				}
				

				if (slotinfo.amount > 1)
				{
					amountText.text = slotinfo.amount.ToString();
					amountText.gameObject.SetActive(true);

				}
				else
					amountText.gameObject.SetActive(false);

			}
		}
		else
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
		
	}


	public void TriggerDescription()
	{
		if (!slotinfo.isEmpty)
		{
			slotinfo.isNewItem = false;

			
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
		else
		{
			StartCoroutine("LockAnim");
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

	IEnumerator LockAnim()
	{

		anim.SetBool("trigger", true);
		yield return new WaitForSeconds(1);

		anim.SetBool("trigger", false);
		yield return null;

	}

}
[System.Serializable]
public class SlotInfo
{
    public int id;
    public bool isEmpty = true;
	public bool isNewItem = false;
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
}
