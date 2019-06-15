using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogosManager : MonoBehaviour
{

	public DialogoTrigger[] triggers;

    public Text nameText;
    public Text dialogueText;
	public Image NPCsprite;
	

    public Animator animator;
	public GameObject dialogPanel;
    private Queue<string> sentences;

	private bool daMision =false;
	public bool tutorialLevel = false;


	public bool intercambia = false;
	public bool entregaItem = false;
	public int itemPremioId;

	[SerializeField]
	private ItemDataBase itemDataBase; //referencia a la base de datos

									   
	void Start()
    {

        sentences = new Queue<string>();
       
    }
    
    public void StartDialogo(Dialogos dialogo)
    {

		
		dialogPanel.SetActive(true);
        nameText.text = dialogo.name;
		

		sentences.Clear();

        foreach (string sentence in dialogo.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextScentence();
    }
	public void NPCSprite(Sprite npc)
	{
		NPCsprite.sprite = npc;
	}
	
	public void GetMission(bool mision)
	{
		daMision = mision;
	}

	public void SetEngregaItem(bool entrega)
	{
		entregaItem = entrega;
		
	}
	public void SetItemID(int item)
	{
		itemPremioId = item;
		
	}
	
	private void AddItem()
	{
		
		ItemDataBase.Item itemid = itemDataBase.FindItemInItemDataBase(itemPremioId); // buscar en la base de datos
		if (itemid.isDiario)
			FindObjectOfType<UIGameManager>().SetDiarioPageWindow(itemPremioId);

		if (itemid.isFauna)
			FindObjectOfType<UIGameManager>().SetFaunaWindow(itemPremioId);

		if (itemid.isFlora)
			FindObjectOfType<UIGameManager>().SetFFWindow(itemPremioId);

		if (itemid.isStackable)
			FindObjectOfType<UIGameManager>().SetPickUpWindow(itemPremioId);
	}
	
	public void DisplayNextScentence()
    {
		FindObjectOfType<UIAudioManager>().Play("siguiente_btn");
		if (sentences.Count == 0)
        {
            EndDialogo();
			if(tutorialLevel)
			gameObject.SendMessage("StartTutorial");
            return;
        }

        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

		
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = sentence;
		
		yield return null;
	}



	public void EndDialogo()
	{
		
		dialogPanel.SetActive(false);
		if (daMision)
			gameObject.SendMessage("GetDialogueStatus", true);

		if (entregaItem)
		{
			entregaItem = false;
			AddItem();
			
			
		}
	
			
		if(nameText.text== "Juan Fuentes")
		{
			
			FindObjectOfType<AudioManager>().Play("Theme");
		}


		if (nameText.text == "Doña Constanza")
		{

			FindObjectOfType<UIGameManager>().EndPrototype(true);

		}

		entregaItem = false;

		foreach (var trigger in triggers)
		{
			SendMessage("StopAllCoroutines");
		}
	}

}
