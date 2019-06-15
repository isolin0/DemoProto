using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoManager : MonoBehaviour {

    public Text itemNameText;
    public Text itemDescriptionText;
    public ItemDataBase itemDatabase;
    public int itemID;
    public Button descartarButton;


    private Queue<string> sentences;

    void Start()
    {

        sentences = new Queue<string>();
    }

    public void StartDescription(int itemId)
    {
        itemID = itemId;

        
            sentences.Clear();

            itemNameText.text = itemDatabase.FindItemInItemDataBase(itemID).name;

           

  
            sentences.Enqueue(itemDatabase.FindItemInItemDataBase(itemID).description);

            descartarButton.gameObject.SetActive(true);
            
        

        DisplayNextDescription();
    }
    
    public void DisplayNextDescription()
    {

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeDescription(sentence));
    }
    public void ItemRemove()
    {
        FindObjectOfType<Inventory>().RemoveItem(itemID);
        
        sentences.Clear();
        itemDescriptionText.text = "";
        itemNameText.text = "";
    }
    IEnumerator TypeDescription(string sentence)
    {
        itemDescriptionText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            itemDescriptionText.text += letter;
            yield return null;

        }
    }

}
