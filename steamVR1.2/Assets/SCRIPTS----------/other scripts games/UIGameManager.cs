using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIGameManager : MonoBehaviour {

	public GameObject windowsCanvas;
	
	public SetWindow FFWindow;
	public GameObject ffWindowGO;

	public SetWindow FaunaWindow;
	public GameObject faunaWindowGO;
	
	public SetWindow DiarioPageWindow;
	public GameObject diarioPageWindowGO;

	
	
	
	public SetWindow PickUpWindow;
	public GameObject pickUpWindowGO;

	public Text pickUpName;
	public Image pickUpImage;
	public GameObject pickupItem;

	public ItemDataBase itemdata;

	
	public GameObject loadingScreen;
	public Slider slider;
	public int activeScene;
	public int sceneCollectables =0;
	public int lvl = 0;

	public bool endProto = false;

	private void Awake()
	{
		Application.targetFrameRate = 60;
	}
	public void Update()
	{
		
		if (lvl == 0)
		{
			if (sceneCollectables >= 8)
			{
				sceneCollectables = 0;
				
				FindObjectOfType<Tutorial1>().EndTutorial();
				lvl += 1;
				

			}
		}
		else if (lvl == 1)
		{
			if (sceneCollectables >= 4)
			{
				sceneCollectables = 0;

				StartCoroutine(LoadAsynchronously(3));
				lvl += 1;
				
			}
		}
		else if (lvl == 2)
		{
			if (sceneCollectables >= 3 && endProto)
			{
				sceneCollectables = 0;

				FindObjectOfType<Tutorial1>().EndDemo();
				lvl += 1;

			}
		}



	}
	public void EndPrototype(bool end)
	{
		endProto = end;
	}

	public void LoadScene(int scene)
    {
		
			StartCoroutine(LoadAsynchronously(scene));
		
		
		
	}

	IEnumerator LoadAsynchronously(int scene)
	{
		if(scene==1)
		loadingScreen.SetActive(true);
		//yield return new WaitForSeconds(3);
		AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
		
		while (!operation.isDone)
		{
			
			float progress = Mathf.Clamp01(operation.progress / 0.9f );
			slider.value = progress;

			
			yield return null;
		}
	}

	public void SceneCollectables()
	{
		sceneCollectables += 1;
		
		if (sceneCollectables == 1)
		{
			FindObjectOfType<Tutorial1>().SetBool(true);
			FindObjectOfType<Tutorial1>().StartTutorial();
			
			
		}
	}

	public void GetItem(GameObject pickup)
	{
		pickup = pickupItem;
	}

	public void SetFFWindow(int itemID)
	{
		ffWindowGO.SetActive(true);
		FFWindow.SetItemID(itemID);
		FFWindow.nameText.text = itemdata.FindItemInItemDataBase(itemID).name;
		FFWindow.image.sprite = itemdata.FindItemInItemDataBase(itemID).itemImage;

		

	}
	public void SetFaunaWindow(int itemID)
	{

		faunaWindowGO.SetActive(true);
		FaunaWindow.SetItemID(itemID);
		FaunaWindow.nameText.text = itemdata.FindItemInItemDataBase(itemID).name;
		FaunaWindow.image.sprite = itemdata.FindItemInItemDataBase(itemID).itemImage;

	}
	public void SetDiarioPageWindow(int itemID)
	{
		diarioPageWindowGO.SetActive(true);
		DiarioPageWindow.SetItemID(itemID);
		DiarioPageWindow.nameText.text = itemdata.FindItemInItemDataBase(itemID).name;
		DiarioPageWindow.description.text = itemdata.FindItemInItemDataBase(itemID).description;


	}
	public void SetPickUpWindow(int itemID)
	{
		pickUpWindowGO.SetActive(true);
		PickUpWindow.SetItemID(itemID);
		PickUpWindow.nameText.text = itemdata.FindItemInItemDataBase(itemID).name;
		PickUpWindow.image.sprite = itemdata.FindItemInItemDataBase(itemID).itemImage;
		
	}
	public void SetItemInactive()
	{
		pickupItem.SetActive(false);
	}


}
