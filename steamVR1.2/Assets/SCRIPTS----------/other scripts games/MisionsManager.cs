using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionsManager : MonoBehaviour {

   // public GameObject mision1;
    public GameObject[] misions;
	public GameObject[] misionsButton;
	private bool endDialogue;
    private int misionNumber;

	public Text titleText;
	public Text misionText;

	private void Start()
    {
        endDialogue = false;
    }
    public void GetMisionTitle(string title)
	{
		titleText.text = title;
	}
	public void GetMisionDescription(string Desc)
	{
		misionText.text = Desc;
	}
    public void GetDialogueStatus(bool end)
    {
        endDialogue = end;
     

        if (endDialogue)
        {
            for (int i = 0; i < misions.Length; i++)
            {
                misions[misionNumber].SetActive(true);
				misionsButton[misionNumber].SetActive(true);
			}
        }
    }
    public void GetMisions(int _mision)
    {
        
        misionNumber = _mision;
        
    }

}
