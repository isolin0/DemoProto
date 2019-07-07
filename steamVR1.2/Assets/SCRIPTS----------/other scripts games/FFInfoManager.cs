using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FFInfoManager : MonoBehaviour
{

    public Text NameText;
	
	public Image ItemImage;
	public Image descriptionImage;
	public Text DescriptionText;
    
	public ItemDataBase ffDatabase;
    public int ffID;



    private Queue<string> sentences;

    void Start()
    {

        sentences = new Queue<string>();
    }

    public void StartDescription(int itemId)
    {
        ffID = itemId;
      

        sentences.Clear();
		NameText.text = ffDatabase.FindItemInItemDataBase(ffID).name;
		ItemImage.sprite = ffDatabase.FindItemInItemDataBase(ffID).itemImage;


		if (ffDatabase.FindItemInItemDataBase(ffID).isDiario)
		{
			DescriptionText.text = ffDatabase.FindItemInItemDataBase(ffID).description;
			
		}else if(ffDatabase.FindItemInItemDataBase(ffID).isStackable)
			{
			DescriptionText.text = ffDatabase.FindItemInItemDataBase(ffID).description;

		}
		else
		{
			
			descriptionImage.sprite = ffDatabase.FindItemInItemDataBase(ffID).descriptionImage;
		}
		
		

         

        

        
    }

    public void ItemRemove()
    {
        FindObjectOfType<Inventory>().RemoveItem(ffID);
       
        sentences.Clear();
        DescriptionText.text = "";
        NameText.text = "";
		
	}
	
}
