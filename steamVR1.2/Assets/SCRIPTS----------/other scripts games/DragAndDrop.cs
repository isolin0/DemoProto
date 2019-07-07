using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	// // este codigo se va a encargar desde el inicio del arrastre durante y hasta que suelta el objeto
	//public Inventory inventory;
	// public Transform inventoryPanel;
	// public Slots mySlot;
	// public Slots destinationSlot;
	// private Image myImage;
	//public Transform handle;
	Vector3 startPosition;

	public GameObject lupaChica;
	public GameObject lupaGrande;
	public GameObject mask;

    public void OnBeginDrag(PointerEventData eventData)
    {
		
		startPosition = transform.position;
		lupaGrande.SetActive(true);
		mask.SetActive(true);
		lupaChica.SetActive(false);
        

    }

    public void OnDrag(PointerEventData eventData)
    {
       
		transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

		transform.position = startPosition;
		lupaGrande.SetActive(false);
		mask.SetActive(false);
		lupaChica.SetActive(true);

		
	}
}
