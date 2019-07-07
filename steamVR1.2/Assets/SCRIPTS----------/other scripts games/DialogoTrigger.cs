using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoTrigger : MonoBehaviour {

 
  
    public int itemId;
    public int itemPremioId;
    public Dialogos[] dialogos;
	public bool intercambia = false;
	public bool entregaItem = false;
	public bool daMision = false;
	public int misionNumber;
	
	public Sprite[] sprites;




	public void TriggerDialogo()
    {
		
		SlotInfo slotInfo = FindObjectOfType<Inventory>().FindItemInInventory(itemId);
		SlotInfo slotInfo2 = FindObjectOfType<FFInventory>().FindItemInInventory(itemId);
		if (intercambia)
		{
			if (slotInfo != null || slotInfo2 != null)
			{
				FindObjectOfType<DialogosManager>().StartDialogo(dialogos[1]);
				
				int randomNumber = Random.Range(0, sprites.Length);
				FindObjectOfType<DialogosManager>().NPCSprite(sprites[randomNumber]);
				
				FindObjectOfType<DialogosManager>().GetMission(daMision);
				Intercambio();
				
			}
			else
			{
				FindObjectOfType<DialogosManager>().StartDialogo(dialogos[0]);
				int randomNumber = Random.Range(0, sprites.Length);
				FindObjectOfType<DialogosManager>().NPCSprite(sprites[randomNumber]);
				
				FindObjectOfType<DialogosManager>().GetMission(daMision);
			}
		}
		else
		{
			FindObjectOfType<DialogosManager>().StartDialogo(dialogos[0]);
			int randomNumber = Random.Range(0, sprites.Length);
			FindObjectOfType<DialogosManager>().NPCSprite(sprites[randomNumber]);

			FindObjectOfType<DialogosManager>().GetMission(daMision);


		}

		if (entregaItem)
		{
			FindObjectOfType<DialogosManager>().SetEngregaItem(true);
			FindObjectOfType<DialogosManager>().SetItemID(itemPremioId);
			
			entregaItem = false;
			
		}

		if (daMision)
		{
			daMision = false;
			FindObjectOfType<MisionsManager>().GetMisions(misionNumber);
			
		}
			
		if (intercambia)
			intercambia = false;

	}

	
    public void Intercambio()
    {
		FindObjectOfType<Inventory>().AddItem(itemPremioId);
		FindObjectOfType<Inventory>().RemoveItem(itemId);
    }
	

	public void TriggerThisDialog(int dialog)
	{
		
		FindObjectOfType<DialogosManager>().StartDialogo(dialogos[dialog]);
		int randomNumber = Random.Range(0, sprites.Length);
		FindObjectOfType<DialogosManager>().NPCSprite(sprites[randomNumber]);
		FindObjectOfType<DialogosManager>().GetMission(daMision);
	}
	public void SendCollectable()
	{
		FindObjectOfType<UIGameManager>().SceneCollectables();
	}

	public void GuittarAudioOff()
	{
		FindObjectOfType<AudioManager>().Play("GuitarStop");
		FindObjectOfType<AudioManager>().Stop("Theme");

	}
	public void GuittarAudiobackOn()
	{
		FindObjectOfType<AudioManager>().Play("Theme");
	}

}
