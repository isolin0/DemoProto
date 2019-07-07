//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Tutorial1 : MonoBehaviour {

	
	public GameObject Darwin;
	
	private bool Tutoria2 = false;
	private bool Tutoria3 = true;
	private bool Tutoria = true;
	private int tutorialStep = 0;
	public GameObject itemWindow;
	public int itemID;
	public ItemDataBase itemdata;
	//public Text itemName;
	//public Text itemDescription;
	public Image itemImage;
	public Animator puerta1;
	public GameObject puertabutton;
	public GameObject mochilaButton;
	public GameObject blackIntro;
	public GameObject fadeinblack;
	public GameObject caciqueAnim;
	public GameObject dialogBlack;
	public GameObject dialogImage;

	private bool endDemo = false;
	private bool openDoor = false;

	public void Start()
	{
		Darwin.SendMessage("TriggerThisDialog", (1));
	}

	public void SetBool(bool tutoriallvl)
	{
		Tutoria2 = tutoriallvl;
	}
	public void StartTutorial()
	{
		
		if (Tutoria && tutorialStep==0)
		{
			Tutoria = false;
			tutorialStep += 1;
			dialogImage.SetActive(true);
			blackIntro.SetActive(false);
			//fadeinblack.SetActive(true);
			Darwin.SendMessage("TriggerThisDialog", (2));
			
		}
		else if (Tutoria2 && tutorialStep==1)
		{
			
			Tutoria2 = false;
			tutorialStep += 1;

			Darwin.SendMessage("TriggerThisDialog", (3));
			mochilaButton.SetActive(true);
		}
		else if (Tutoria2 && tutorialStep==2)
		{
			Tutoria2 = false;
			tutorialStep += 1;
			Darwin.SendMessage("TriggerThisDialog", (4));
		}
		else if(openDoor && tutorialStep == 3)
		{
			openDoor = false;
			FindObjectOfType<AudioManager>().Play("PuertaLvl1");
			puertabutton.SetActive(true);
			puerta1.SetTrigger("openDoor");
		}
		else if(endDemo && tutorialStep == 3)
		{
			endDemo = false;
			tutorialStep = 0;
		//	FindObjectOfType<UIGameManager>().LoadScene(0);
		//	FindObjectOfType<Quite>().DoQuite();
		}
		
		

	
	}

	public void EndTutorial()
	{
		Darwin.SendMessage("TriggerThisDialog", (5));
		openDoor = true;
	}
	public void EndDemo()
	{
		Darwin.SendMessage("TriggerThisDialog", (6));
		endDemo = true;
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