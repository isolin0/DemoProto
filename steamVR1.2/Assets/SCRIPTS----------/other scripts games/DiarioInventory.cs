using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiarioInventory : MonoBehaviour
{
    /// <summary>
    /// ESTE SCRIPT DEBERIA IR EN EL JUGADOR
    /// </summary>
    [SerializeField]
    private ItemDataBase itemDataBase; //referencia a la base de datos
    [SerializeField]
    private GameObject slotPrefab; // referencia al prefab del slot
    [SerializeField]
    private Transform inventoryPanel; // referencia al panel de inventario
    [SerializeField]
    private List<SlotInfo> slotInfoList; // lista con la informacion de todos los slot(inventario )
    [SerializeField]
    private int capacity; // capacidad del inventario

    private string jsonString; // texto en formato json que usaremos para guardar el inventario.

	//public Animator anim;
	
	private void Awake()
	{
		
		for (int i = 0; i < capacity; i++)
		{
			RemoveItem(i);
		}
		SaveInventory();
	}
	private void Start()
    {
        //PlayerPrefs.DeleteAll();
        slotInfoList = new List<SlotInfo>();
        if (PlayerPrefs.HasKey("Diarioinventory"))
        {
          LoadSavedInventory();
        }
        else
        {
            //crear uno nuevo
           LoadEmptyInventory();
           
        }
        ///////AddItems/////
       // loadItems();
    }

    public void InventoryOn(bool state)
    {
      //  anim.SetBool("inventoryOn", state);
    }
    public void LoadEmptyInventory()
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject slot = Instantiate<GameObject>(slotPrefab, inventoryPanel);
            Slots newslot = slot.GetComponent<Slots>();
            newslot.SetUp(i);
            newslot.itemDataBase = itemDataBase;
            SlotInfo newSlotInfo = newslot.slotinfo;
            slotInfoList.Add(newSlotInfo);



        }
    }
    private void LoadSavedInventory()
    {
        jsonString = PlayerPrefs.GetString("Diarioinventory");
        InventoryWrapper inventoryWrapper = JsonUtility.FromJson<InventoryWrapper>(jsonString);
        this.slotInfoList = inventoryWrapper.slotInfoList;

        for (int i = 0; i < capacity; i++)
        {
            GameObject slot = Instantiate<GameObject>(slotPrefab, inventoryPanel);
            Slots newslot = slot.GetComponent<Slots>();
            newslot.SetUp(i);
            newslot.itemDataBase = itemDataBase;
            newslot.slotinfo = slotInfoList[i];
            newslot.UpdateUI();



        }
    }
    public void loadItems()
    {
        for (int i = 0; i < capacity; i++)
        {
            AddItem(i);
        }
    }


    public SlotInfo FindItemInInventory(int itemId)
    {
        foreach (SlotInfo slotInfo in slotInfoList)
        {
            if (slotInfo.itemId == itemId && !slotInfo.isEmpty)
            {
                return slotInfo;
            }
        }
        return null;
    }

    private SlotInfo FindSuitableSlot(int itemid)
    {
        foreach (SlotInfo slotInfo in slotInfoList)
        {
          
            if (slotInfo.id == itemid )
            {
                return slotInfo;
            }
        }
       

        foreach (SlotInfo slotInfo in slotInfoList)
        {
            if (slotInfo.isEmpty)
            {
                slotInfo.EmptySlot();
                return slotInfo;
            }
        }
        return null;
    }

    private Slots FindSlot(int id)
    {
        return inventoryPanel.GetChild(id).GetComponent<Slots>();
    }
    public void AddItem(int itemId)
    {
        ItemDataBase.Item item = itemDataBase.FindItemInItemDataBase(itemId); // buscar en la base de datos
        if (item != null)
        {
			FindObjectOfType<UIGameManager>().SceneCollectables();
			FindObjectOfType<UI_VFX_Frome_to>().FromTo();
			SlotInfo slotInfo = FindSuitableSlot(itemId); // = // encontramos en donde guardar el item; Este slotinfo es una referencia al slot real.
            if (slotInfo != null)
            {
                //slotInfo.amount++;
                slotInfo.itemId = itemId;
                slotInfo.isEmpty = false;
				slotInfo.isNewItem = true;
				FindSlot(slotInfo.id).UpdateUI();
            }
        }
    }

    public void RemoveItem(int itemId)
    {
        SlotInfo slotInfo = FindItemInInventory(itemId);
        if (slotInfo != null)
        {
            if (slotInfo.amount == 1)
            {
                slotInfo.EmptySlot();
            }
            else
            {
                slotInfo.amount--;
            }
            FindSlot(slotInfo.id).UpdateUI();
        }
    }
    public void RemoveItem(int itemId, SlotInfo slotInfo)
    {

        if (slotInfo != null)
        {
            if (slotInfo.amount == 1)
            {
                slotInfo.EmptySlot();
            }
            else
            {
                slotInfo.amount--;
            }
            FindSlot(slotInfo.id).UpdateUI();
        }
    }


    public void SaveInventory()
    {
        InventoryWrapper inventoryWrapper = new InventoryWrapper();
        inventoryWrapper.slotInfoList = this.slotInfoList;
        jsonString = JsonUtility.ToJson(inventoryWrapper);
        PlayerPrefs.SetString("Diarioinventory", jsonString);
    }

    public void SwapSlots(int id_o, int id_d, Transform image_o, Transform image_d)
    {
        // swap de las imagenes
        image_o.SetParent(inventoryPanel.GetChild(id_d));
        image_d.SetParent(inventoryPanel.GetChild(id_o));
        image_o.localPosition = Vector3.zero;
        image_d.localPosition = Vector3.zero;

        if (id_o != id_d)
        {
            SlotInfo origin = slotInfoList[id_o];
            SlotInfo destination = slotInfoList[id_d];
            // swap en el inventario
            slotInfoList[id_o] = destination;
            slotInfoList[id_o].id = id_o;
            slotInfoList[id_d] = origin;
            slotInfoList[id_d].id = id_d;

            //swap en los slot basados en los cambios en el inventario
            Slots originSlot = inventoryPanel.GetChild(id_o).GetComponent<Slots>();
            originSlot.slotinfo = slotInfoList[id_o];
            Slots DestinationSlot = inventoryPanel.GetChild(id_d).GetComponent<Slots>();
            DestinationSlot.slotinfo = slotInfoList[id_d];

            originSlot.itemImage = image_d.GetComponent<Image>();
            DestinationSlot.itemImage = image_o.GetComponent<Image>();

            originSlot.amountText = originSlot.itemImage.transform.GetChild(0).GetComponent<Text>();
            DestinationSlot.amountText = DestinationSlot.itemImage.transform.GetChild(0).GetComponent<Text>();
        }

    }

    private struct InventoryWrapper
    {
        public List<SlotInfo> slotInfoList;
    }


    [ContextMenu("test Add - itemId =1")]
    public void TestAdd()
    {
        AddItem(6);
    }
    [ContextMenu("test Add - itemId =2")]
    public void TestAdd2()
    {
        AddItem(4);
    }
    [ContextMenu("test Add - itemId =3")]
    public void TestAdd3()
    {
        AddItem(3);
    }
    [ContextMenu("test Remove - itemId =1")]
    public void TestRemove()
    {
        RemoveItem(1);
    }
    [ContextMenu("test Save")]
    public void TestSave()
    {
        SaveInventory();
    }
}

